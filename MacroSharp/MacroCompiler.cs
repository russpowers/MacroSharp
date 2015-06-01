using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroSharp
{
    class MacroCompiler : ICompilerPlugin
    {
        private AssemblyLoader _assemblyLoader;

        public MacroCompiler()
        {
            _assemblyLoader = new AssemblyLoader();
        }

        public void BeforeCompile(BeforeCompileContext context)
        {
            var wellKnownTypes = new WellKnownTypes(context.Compilation);
            var registry = new MacroRegistry(context.Compilation, _assemblyLoader, wellKnownTypes);
            var symbolVisitor = new MacroSymbolVisitor(context.Compilation, wellKnownTypes, registry);

            foreach (var s in context.Compilation.SourceModule.GlobalNamespace.GetMembers())
                s.Accept(symbolVisitor);

            context.Compilation = symbolVisitor.Compilation;
            foreach (var diagnostic in symbolVisitor.Diagnostics)
                context.Diagnostics.Add(diagnostic);
        }

        public void AfterCompile(AfterCompileContext context)
        {
        }

        public void Dispose()
        {
            _assemblyLoader.Dispose();
        }
    }
}
