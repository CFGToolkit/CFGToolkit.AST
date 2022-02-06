using System;
using System.Collections.Generic;
using System.Linq;

namespace CFGToolkit.AST.Providers
{
    public static class TokenProvider
    {
        public static List<SyntaxToken> GetTokens(this SyntaxNode node)
        {
            var list = new List<SyntaxToken>();

            Func<ISyntaxElement, int, bool> accept = (element, depth) =>
            {
                if (element is SyntaxToken token)
                {
                    list.Add(token);
                }

                return true;
            };

            var vistor = new Algorithms.TreeVisitors.PostOrderTreeVistor(accept);
            vistor.Visit(node, 0);

            return list;
        }

        public static SyntaxToken GetFirstToken(this SyntaxNode node)
        {
            var list = new List<SyntaxToken>();

            Func<ISyntaxElement, int, bool> accept = (element, depth) =>
            {
                if (element is SyntaxToken token)
                {
                    list.Add(token);
                    return false;
                }

                return true;
            };

            var vistor = new Algorithms.TreeVisitors.PostOrderTreeVistor(accept);
            vistor.Visit(node, 0);

            return list.FirstOrDefault();
        }

        public static SyntaxToken GetLastToken(SyntaxNode node)
        {
            return GetTokens(node).LastOrDefault();
        }
    }
}
