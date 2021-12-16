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

            Func<ISyntaxElement, bool> accept = (element) =>
            {
                if (element is SyntaxToken token)
                {
                    list.Add(token);
                }

                return true;
            };

            var vistor = new Algorithms.TreeVisitors.PostOrderTreeVistor(accept);
            vistor.Visit(node);

            return list;
        }

        public static SyntaxToken GetFirstToken(this SyntaxNode node)
        {
            var list = new List<SyntaxToken>();

            Func<ISyntaxElement, bool> accept = (element) =>
            {
                if (element is SyntaxToken token)
                {
                    list.Add(token);
                    return false;
                }

                return true;
            };

            var vistor = new Algorithms.TreeVisitors.PostOrderTreeVistor(accept);
            vistor.Visit(node);

            return list.FirstOrDefault();
        }

        public static SyntaxToken GetLastToken(SyntaxNode node)
        {
            return GetTokens(node).LastOrDefault();
        }
    }
}
