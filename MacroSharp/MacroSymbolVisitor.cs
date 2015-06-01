using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroSharp
{
    class MacroSymbolVisitor : SymbolVisitor<object>
    {
        public struct SyntaxPair
        {
            public SyntaxPair(SyntaxNode oldNode, SyntaxNode newNode)
            {
                OldNode = oldNode;
                NewNode = newNode;
            }
            public SyntaxNode OldNode { get; }
            public SyntaxNode NewNode { get; }
        }

        private Compilation _compilation;
        private readonly WellKnownTypes _wellKnownTypes;
        private readonly MacroRegistry _registry;
        private readonly TransformContext _transformContext;
        private readonly List<Diagnostic> _diagnostics;

        public MacroSymbolVisitor(Compilation compilation, WellKnownTypes wellKnownTypes, MacroRegistry registry)
        {
            _compilation = compilation;
            _wellKnownTypes = wellKnownTypes;
            _registry = registry;
            _transformContext = new TransformContext();
            _diagnostics = new List<Diagnostic>();
        }

        public Dictionary<SyntaxTree, List<SyntaxPair>> UpdatedNodes = new Dictionary<SyntaxTree, List<SyntaxPair>>();

        public override object VisitNamespace(INamespaceSymbol symbol)
        {
            foreach (var s in symbol.GetMembers())
                s.Accept(this);

            return null;
        }

        public override object VisitNamedType(INamedTypeSymbol symbol)
        {
            if (TransformSymbolWithMacroAttribute(symbol, _wellKnownTypes.TypeMacroAttribute))
                return null;

            foreach (var s in symbol.GetMembers())
                s.Accept(this);

            return null;
        }

        public override object VisitMethod(IMethodSymbol method)
        {
            TransformSymbolWithMacroAttribute(method, _wellKnownTypes.MethodMacroAttribute);
            return null;
        }

        private bool TransformSymbolWithMacroAttribute(ISymbol symbol, INamedTypeSymbol macroAttribute)
        {
            var attributes = symbol.GetAttributes();

            if (attributes.Length == 0)
                return false;

            var attributeData = attributes.SingleOrDefault(x => x.AttributeClass.BaseType == macroAttribute);

            if (attributeData == null)
                return false;

            var transform = _registry.GetMacroTransformFor(attributeData);

            // If there are multiple references, this must be a partial class, we can't transform that
            var syntaxReference = symbol.DeclaringSyntaxReferences.Single();


            // This should be called before bind, which should not trigger a parse
            var originalNode = syntaxReference.GetSyntax();

            _transformContext.Diagnostics.Clear();
            _transformContext.Compilation = _compilation;
            _transformContext.AttributeData = attributeData;
            _transformContext.SyntaxNode = originalNode;
            _transformContext.Symbol = symbol;

            var transformed = transform.Transform(_transformContext);

            _diagnostics.AddRange(_transformContext.Diagnostics);

            if (transformed != null && transformed != originalNode)
            {
                var originalTree = originalNode.SyntaxTree;
                var originalRoot = originalTree.GetRoot();
                var transformedRoot = originalRoot.ReplaceNode(originalNode, transformed);
                var transformedTree = originalTree.WithRootAndOptions(transformedRoot, originalTree.Options);
                _compilation = _compilation.ReplaceSyntaxTree(originalTree, transformedTree);

                // We will need to re-compute the semantic model since the compilation has been modified
                _transformContext.ResetSemanticModel();

                return true;
            }
            else
                return false;
        }

        public Compilation Compilation => _compilation;
        public List<Diagnostic> Diagnostics => _diagnostics;
    }
}
