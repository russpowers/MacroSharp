using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroSharp
{
    public class MacroCSharpSyntaxRewriter : CSharpSyntaxRewriter
    {
        private const int MaxListRecursion = 20;

        protected TransformContext Context => _context;

        public virtual SyntaxNode Run(TransformContext context)
        {
            _context = context;
            return Visit(context.SyntaxNode);
        }

        private struct ListData
        {
            public List<SyntaxNode> PrependedNodes;
            public List<SyntaxNode> AppendedNodes;
        }

        public override SyntaxList<TNode> VisitList<TNode>(SyntaxList<TNode> list)
        {
            _listDataIndex += 1;
            List<SyntaxNode> alternate = null;
            for (int i = 0, n = list.Count; i < n; i++)
            {
                var item = list[i];
                var visited = this.VisitListElement(item);
                var prepended = _listData[_listDataIndex].PrependedNodes;
                var appended = _listData[_listDataIndex].AppendedNodes;

                if (item != visited ||
                    (prepended != null && prepended.Count > 0) ||
                    (appended != null && appended.Count > 0))
                {
                    if (alternate == null)
                    {
                        alternate = new List<SyntaxNode>(n);
                        for (int j = 0; j < i; ++j)
                            alternate.Add(list[j]);
                    }

                    if (prepended != null && prepended.Count > 0)
                    {
                        alternate.AddRange(prepended);
                        prepended.Clear();
                    }

                    if (visited != null && !visited.IsKind(SyntaxKind.None))
                        alternate.Add(visited);

                    if (appended != null && appended.Count > 0)
                    {
                        alternate.AddRange(appended);
                        appended.Clear();
                    }
                }
                else if (alternate != null && visited != null && !visited.IsKind(SyntaxKind.None))
                    alternate.Add(visited);
            }

            _listDataIndex -= 1;

            if (alternate != null)
                return SyntaxFactory.List(alternate);

            return list;
        }

        public void AddAfterCurrentNode(SyntaxNode node)
        {
            if (_listData[_listDataIndex].AppendedNodes == null)
                _listData[_listDataIndex].AppendedNodes = new List<SyntaxNode>();

            _listData[_listDataIndex].AppendedNodes.Add(node);
        }

        public void AddBeforeCurrentNode(SyntaxNode node)
        {
            if (_listData[_listDataIndex].PrependedNodes == null)
                _listData[_listDataIndex].PrependedNodes = new List<SyntaxNode>();

            _listData[_listDataIndex].PrependedNodes.Add(node);
        }

        private TransformContext _context;
        private int _listDataIndex = -1;
        private ListData[] _listData = new ListData[MaxListRecursion];
    }
}
