using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MacroSharp
{
    class MacroRegistry
    {
        private class RegisteredAssembly
        {
            public readonly Assembly Assembly;
            public readonly Dictionary<string, IMacroTransform> Macros;

            public RegisteredAssembly(Assembly assembly)
            {
                Assembly = assembly;
                Macros = new Dictionary<string, IMacroTransform>();
            }
        }

        private readonly Compilation _compilation;
        private readonly AssemblyLoader _assemblyLoader;
        private readonly WellKnownTypes _wellKnownTypes;
        private readonly Dictionary<IAssemblySymbol, RegisteredAssembly> _registeredAssemblies;

        public MacroRegistry(Compilation compilation, AssemblyLoader assemblyLoader, WellKnownTypes wellKnownTypes)
        {
            _compilation = compilation;
            _assemblyLoader = assemblyLoader;
            _wellKnownTypes = wellKnownTypes;
            _registeredAssemblies = new Dictionary<IAssemblySymbol, RegisteredAssembly>();
        }

        public IMacroTransform GetMacroTransformFor(AttributeData attribute)
        {
            var containingAssembly = attribute.AttributeClass.ContainingAssembly;
            RegisteredAssembly registeredAssembly;

            if (!_registeredAssemblies.TryGetValue(containingAssembly, out registeredAssembly))
                registeredAssembly = RegisterAssembly(containingAssembly);

            return registeredAssembly.Macros[attribute.AttributeClass.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)];
        }

        private RegisteredAssembly RegisterAssembly(IAssemblySymbol assemblySymbol)
        {
            var macroAssemblyPath = _compilation.GetMetadataReference(assemblySymbol).Display;
            var macroAssembly = _assemblyLoader.LoadFromPath(macroAssemblyPath);
            var registeredAssembly = new RegisteredAssembly(macroAssembly);

            foreach (var type in macroAssembly.DefinedTypes)
            {
                var methodAttribute = GetFirstArgumentOfGenericAncestor(typeof(MacroTransform<>), type);
                if (methodAttribute != null)
                {
                    registeredAssembly.Macros.Add("global::" + methodAttribute.FullName, (IMacroTransform)Activator.CreateInstance(type));
                }
            }

            _registeredAssemblies.Add(assemblySymbol, registeredAssembly);
            return registeredAssembly;
        }

        static Type GetFirstArgumentOfGenericAncestor(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var toCheckInfo = toCheck.GetTypeInfo();
                var cur = toCheckInfo.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return toCheck.GenericTypeArguments[0];
                }
                toCheck = toCheckInfo.BaseType;
            }
            return null;
        }
    }
}
