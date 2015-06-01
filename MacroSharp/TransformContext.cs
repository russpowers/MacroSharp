using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroSharp
{
    public class TransformContext
    {
        public TransformContext()
        {
            Diagnostics = new List<Diagnostic>();
        }

        internal void ResetSemanticModel()
        {
            _lazySemanticModel = null;
        }

        public Compilation Compilation { get; internal set; }
        public AttributeData AttributeData { get; internal set; }
        public SyntaxNode SyntaxNode { get; internal set; }
        public ISymbol Symbol { get; internal set; }
        public IList<Diagnostic> Diagnostics { get; private set; }
        private SemanticModel _lazySemanticModel;
        public SemanticModel SemanticModel
        {
            get
            {
                if (_lazySemanticModel == null)
                    _lazySemanticModel = Compilation.GetSemanticModel(SyntaxNode.SyntaxTree);

                return _lazySemanticModel;
            }
        }
    }
}
