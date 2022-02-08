using CFGToolkit.AST.Visitors;
using CFGToolkit.AST.Visitors.Traversals;
using System.Collections.Generic;
using System.Linq;

namespace CFGToolkit.AST.Providers
{
    public static class TokenProvider
    {
        public class AllTokenFinderVisitor : IVisitor<ISyntaxElement, TreeTraversalContext, List<SyntaxToken>>
        {
            private List<SyntaxToken> _elements = new List<SyntaxToken>();

            public AllTokenFinderVisitor()
            {
            }

            public List<SyntaxToken> Visit(ISyntaxElement element, TreeTraversalContext context)
            {
                if (element is SyntaxToken token)
                {
                    _elements.Add(token);
                }

                return _elements;
            }
        }

        public class FirstTokenFinderVisitor : IVisitor<ISyntaxElement, TreeTraversalContext, SyntaxToken>
        {
            private SyntaxToken _token;

            public FirstTokenFinderVisitor()
            {
            }

            public SyntaxToken Visit(ISyntaxElement element, TreeTraversalContext context)
            {
                if (element is SyntaxToken token)
                {
                    context.Continue = false;
                    _token = token;
                }

                return _token;
            }
        }

        public static List<SyntaxToken> GetTokens(this SyntaxNode node)
        {
            var traversal = new PostOrderTreeTraversal<List<SyntaxToken>>(new AllTokenFinderVisitor());
            return traversal.Accept(node, new TreeTraversalContext { Depth = 0 });
        }

        public static SyntaxToken GetFirstToken(this SyntaxNode node)
        {
            var traversal = new PostOrderTreeTraversal<SyntaxToken>(new FirstTokenFinderVisitor());
            return traversal.Accept(node, new TreeTraversalContext { Depth = 0 });
        }
    }
}
