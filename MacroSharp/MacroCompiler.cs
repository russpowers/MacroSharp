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
            {
                s.Accept(symbolVisitor);
            }

            /*foreach (var treeToUpdate in _symbolVisitor.UpdatedNodes.Keys)
			{
				var pairs = _symbolVisitor.UpdatedNodes[treeToUpdate];
				var newRoot = treeToUpdate.GetRoot()
					.ReplaceNodes(pairs.Select(x => x.OldNode), (old, newer) => pairs.First(x => x.OldNode == old).NewNode);

				var newTree = treeToUpdate.WithRootAndOptions(newRoot, treeToUpdate.Options);

				compilation = compilation.ReplaceSyntaxTree(treeToUpdate, newTree);
			}*/

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
