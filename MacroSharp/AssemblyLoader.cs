// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Roslyn.Utilities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.CodeAnalysis;
using System.Reflection.PortableExecutable;
using System.Reflection.Metadata;

namespace MacroSharp
{
    /// <summary>
    /// A combination of Roslyn's AbstractAnalyzerAssemblyLoader and ShadowCopyAnalyzerAssemblyLoader
    /// that supports assembly reloading.
    /// </remarks>
    class AssemblyLoader : IDisposable
    {
        private struct AssemblyWithLastModified
        {
            public AssemblyWithLastModified(Assembly assembly, DateTime modified)
            {
                Assembly = assembly;
                LastModified = modified;
            }

            public readonly Assembly Assembly;
            public readonly DateTime LastModified;
        }

        private readonly Dictionary<string, AssemblyWithLastModified> _pathsToAssemblies = new Dictionary<string, AssemblyWithLastModified>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, AssemblyWithLastModified> _namesToAssemblies = new Dictionary<string, AssemblyWithLastModified>();
        private readonly List<string> _dependencyPaths = new List<string>();
        private readonly object _guard = new object();

        private bool _hookedAssemblyResolve;

        /// <summary>
        /// Implemented by derived types to handle the actual loading of an assembly from
        /// a file on disk, and any bookkeeping specific to the derived type.
        /// </summary>
        public void AddDependencyLocation(string fullPath)
        {
            if (fullPath == null)
            {
                throw new ArgumentNullException(nameof(fullPath));
            }

            lock (_guard)
            {
                if (!_dependencyPaths.Contains(fullPath, StringComparer.OrdinalIgnoreCase))
                {
                    _dependencyPaths.Add(fullPath);
                }
            }
        }

        public Assembly LoadFromPath(string fullPath)
        {
            if (fullPath == null)
            {
                throw new ArgumentNullException(nameof(fullPath));
            }

            Debug.Assert(Path.IsPathRooted(fullPath));

            lock (_guard)
            {
                AssemblyWithLastModified assemblyLM;
                if (_pathsToAssemblies.TryGetValue(fullPath, out assemblyLM))
                {
                    if (assemblyLM.LastModified == GetLastModified(fullPath))
                        return assemblyLM.Assembly;
                }

                assemblyLM = LoadInternal(fullPath);

                if (!_hookedAssemblyResolve)
                {
                    _hookedAssemblyResolve = true;

                    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                }

                return assemblyLM.Assembly;
            }
        }

        private AssemblyWithLastModified LoadInternal(string fullPath)
        {
            Assembly assembly = LoadCore(fullPath);
            string assemblyName = assembly.FullName;
            DateTime lastModified = GetLastModified(fullPath);
            AssemblyWithLastModified assemblyWT = new AssemblyWithLastModified(assembly, lastModified);

            _pathsToAssemblies[fullPath] = assemblyWT;
            _namesToAssemblies[assemblyName] = assemblyWT;

            return assemblyWT;
        }

        private DateTime GetLastModified(string fullPath) => File.GetLastWriteTime(fullPath);

        /// <summary>
        /// Handler for <see cref="AppDomain.AssemblyResolve"/>. Delegates to <see cref="AssemblyResolveInternal(ResolveEventArgs)"/>
        /// and prevents exceptions from leaking out.
        /// </summary>
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                return AssemblyResolveInternal(args);
            }
            catch
            {
                return null;
            }
        }

        private Assembly AssemblyResolveInternal(ResolveEventArgs args)
        {
            string requestedNameWithPolicyApplied = AppDomain.CurrentDomain.ApplyPolicy(args.Name);

            lock (_guard)
            {
                AssemblyWithLastModified assemblyLM;
                if (_namesToAssemblies.TryGetValue(requestedNameWithPolicyApplied, out assemblyLM))
                {
                    return assemblyLM.Assembly;
                }

                AssemblyIdentity requestedAssemblyIdentity;
                if (!AssemblyIdentity.TryParseDisplayName(requestedNameWithPolicyApplied, out requestedAssemblyIdentity))
                {
                    return null;
                }

                foreach (string candidatePath in _dependencyPaths)
                {
                    if (AssemblyAlreadyLoaded(candidatePath) ||
                        !FileMatchesAssemblyName(candidatePath, requestedAssemblyIdentity.Name))
                    {
                        continue;
                    }

                    AssemblyIdentity candidateIdentity = TryGetAssemblyIdentity(candidatePath);

                    if (requestedAssemblyIdentity.Equals(candidateIdentity))
                    {
                        return LoadInternal(candidatePath).Assembly;
                    }
                }

                return null;
            }
        }

        private bool AssemblyAlreadyLoaded(string path)
        {
            return _pathsToAssemblies.ContainsKey(path);
        }

        private bool FileMatchesAssemblyName(string path, string assemblySimpleName)
        {
            return Path.GetFileNameWithoutExtension(path).Equals(assemblySimpleName, StringComparison.OrdinalIgnoreCase);
        }

        private static AssemblyIdentity TryGetAssemblyIdentity(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return null;
                }

                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete))
                using (var peReader = new PEReader(stream))
                {
                    var metadataReader = peReader.GetMetadataReader();

                    AssemblyDefinition assemblyDefinition = metadataReader.GetAssemblyDefinition();

                    string name = metadataReader.GetString(assemblyDefinition.Name);
                    Version version = assemblyDefinition.Version;

                    StringHandle cultureHandle = assemblyDefinition.Culture;
                    string cultureName = (!cultureHandle.IsNil) ? metadataReader.GetString(cultureHandle) : null;
                    AssemblyFlags flags = assemblyDefinition.Flags;

                    bool hasPublicKey = (flags & AssemblyFlags.PublicKey) != 0;
                    BlobHandle publicKeyHandle = assemblyDefinition.PublicKey;
                    ImmutableArray<byte> publicKeyOrToken = !publicKeyHandle.IsNil
                        ? metadataReader.GetBlobBytes(publicKeyHandle).AsImmutableOrNull()
                        : default(ImmutableArray<byte>);
                    return new AssemblyIdentity(name, version, cultureName, publicKeyOrToken, hasPublicKey);
                }
            }
            catch { }

            return null;
        }

        // Below is a slightly modified copy of ShadowCopyAnalyzerAssemblyLoader.
        // See the remarks section above for a detailed discussion.

        /// <summary>
        /// The base directory for shadow copies. Each instance of
        /// <see cref="ShadowCopyAnalyzerAssemblyLoader"/> gets its own
        /// subdirectory under this directory. This is also the starting point
        /// for scavenge operations.
        /// </summary>
        private readonly string _baseDirectory;

        /// <summary>
        /// The directory where this instance of <see cref="ShadowCopyAnalyzerAssemblyLoader"/>
        /// will shadow-copy assemblies.
        /// </summary>
        private string _shadowCopyDirectory;
        private Mutex _shadowCopyDirectoryMutex;

        /// <summary>
        /// Used to generate unique names for per-assembly directories.
        /// </summary>
        private int _assemblyDirectoryId;

        public AssemblyLoader(string baseDirectory = null)
        {
            if (baseDirectory != null)
            {
                _baseDirectory = baseDirectory;
            }
            else
            {
                _baseDirectory = Path.Combine(Path.GetTempPath(), "MacroSharp", "AnalyzerShadowCopies");
            }

            Directory.CreateDirectory(_baseDirectory);
            DeleteLeftoverDirectories();
        }

        public void Dispose()
        {
            DeleteLeftoverDirectories();
        }

        private void DeleteLeftoverDirectories()
        {
            foreach (var subDirectory in Directory.EnumerateDirectories(_baseDirectory))
            {
                string name = Path.GetFileName(subDirectory).ToLowerInvariant();
                Mutex mutex = null;
                try
                {
                    // We only want to try deleting the directory if no one else is currently
                    // using it. That is, if there is no corresponding mutex.
                    if (!Mutex.TryOpenExisting(name, out mutex))
                    {
                        ClearReadOnlyFlagOnFiles(subDirectory);
                        Directory.Delete(subDirectory, recursive: true);
                    }
                }
                catch
                {
                    // If something goes wrong we will leave it to the next run to clean up.
                    // Just swallow the exception and move on.
                }
                finally
                {
                    if (mutex != null)
                    {
                        mutex.Dispose();
                    }
                }
            }
        }

        private Assembly LoadCore(string fullPath)
        {
            if (_shadowCopyDirectory == null)
            {
                _shadowCopyDirectory = CreateUniqueDirectoryForProcess();
            }

            string assemblyDirectory = CreateUniqueDirectoryForAssembly();
            string shadowCopyPath = CopyFileAndResources(fullPath, assemblyDirectory);

            return Assembly.LoadFile(shadowCopyPath);
        }

        private string CopyFileAndResources(string fullPath, string assemblyDirectory)
        {
            string fileNameWithExtension = Path.GetFileName(fullPath);
            string shadowCopyPath = Path.Combine(assemblyDirectory, fileNameWithExtension);

            CopyFile(fullPath, shadowCopyPath);

            string originalDirectory = Path.GetDirectoryName(fullPath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileNameWithExtension);
            string resourcesNameWithoutExtension = fileNameWithoutExtension + ".resources";
            string resourcesNameWithExtension = resourcesNameWithoutExtension + ".dll";

            foreach (var directory in Directory.EnumerateDirectories(originalDirectory))
            {
                string directoryName = Path.GetFileName(directory);

                string resourcesPath = Path.Combine(directory, resourcesNameWithExtension);
                if (File.Exists(resourcesPath))
                {
                    string resourcesShadowCopyPath = Path.Combine(assemblyDirectory, directoryName, resourcesNameWithExtension);
                    CopyFile(resourcesPath, resourcesShadowCopyPath);
                }

                resourcesPath = Path.Combine(directory, resourcesNameWithoutExtension, resourcesNameWithExtension);
                if (File.Exists(resourcesPath))
                {
                    string resourcesShadowCopyPath = Path.Combine(assemblyDirectory, directoryName, resourcesNameWithoutExtension, resourcesNameWithExtension);
                    CopyFile(resourcesPath, resourcesShadowCopyPath);
                }
            }

            return shadowCopyPath;
        }

        private void CopyFile(string originalPath, string shadowCopyPath)
        {
            var directory = Path.GetDirectoryName(shadowCopyPath);
            Directory.CreateDirectory(directory);

            File.Copy(originalPath, shadowCopyPath);

            ClearReadOnlyFlagOnFile(new FileInfo(shadowCopyPath));
        }

        private void ClearReadOnlyFlagOnFiles(string directoryPath)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            foreach (var file in directory.EnumerateFiles(searchPattern: "*", searchOption: SearchOption.AllDirectories))
            {
                ClearReadOnlyFlagOnFile(file);
            }
        }

        private void ClearReadOnlyFlagOnFile(FileInfo fileInfo)
        {
            try
            {
                if (fileInfo.IsReadOnly)
                {
                    fileInfo.IsReadOnly = false;
                }
            }
            catch
            {
                // There are many reasons this could fail. Ignore it and keep going.
            }
        }

        private string CreateUniqueDirectoryForAssembly()
        {
            int directoryId = _assemblyDirectoryId++;

            string directory = Path.Combine(_shadowCopyDirectory, directoryId.ToString());

            Directory.CreateDirectory(directory);
            return directory;
        }

        private string CreateUniqueDirectoryForProcess()
        {
            string guid = Guid.NewGuid().ToString("N").ToLowerInvariant();
            string directory = Path.Combine(_baseDirectory, guid);

            _shadowCopyDirectoryMutex = new Mutex(initiallyOwned: false, name: guid);

            Directory.CreateDirectory(directory);

            return directory;
        }
    }

    static class RoslynCompatibilityExtensions
    {
        public static ImmutableArray<T> AsImmutableOrNull<T>(this T[] items)
        {
            if (items == null)
            {
                return default(ImmutableArray<T>);
            }

            return ImmutableArray.Create<T>(items);
        }
    }
}
