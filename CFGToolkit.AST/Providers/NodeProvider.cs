using System;
using System.Collections.Generic;

namespace CFGToolkit.AST.Providers
{
    public static class NodeProvider
    {
        public static List<SyntaxNode> GetNodes(this SyntaxNode parentNode, string nodeName, int lookupDepth)
        {
            var list = new List<SyntaxNode>();

            Func<ISyntaxElement, int, bool> accept = (element, depth) =>
            {
                if (depth > lookupDepth)
                {
                    return false;
                }

                if (element is SyntaxNode elementNode && elementNode.Name == nodeName)
                {
                    list.Add(elementNode);
                }

                return true;
            };

            var vistor = new Algorithms.TreeVisitors.PreOrderTreeVistor(accept);
            vistor.Visit(parentNode, 0);

            return list;
        }
    }
}
