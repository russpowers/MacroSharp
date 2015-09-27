using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace MacroSharp
{
    public static class SyntaxFactoryExtensions
    {
        public static TNode WithLineTriviaFrom<TNode>(this TNode node, SyntaxNode originalNode)
            where TNode : SyntaxNode
        {
            var lineSpan = originalNode.GetLocation().GetLineSpan();

            return node
                .WithLeadingTrivia(F.Trivia(F.LineDirectiveTrivia(F.Literal(lineSpan.Span.Start.Line), true)), F.CarriageReturn)
                .WithTrailingTrivia(F.CarriageReturn);

        }
    }
}
