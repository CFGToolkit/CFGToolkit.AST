using System;
using System.Collections.Generic;

namespace CFGToolkit.AST.Providers
{
    public static class NodeProvider
    {
        public static List<SyntaxNode> GetNodes(this SyntaxNode node, string name, int lookupDepth)
        {
            var list = new List<SyntaxNode>();

            Func<ISyntaxElement, bool> accept = (element) =>
            {
                if (element is SyntaxNode elementNode && elementNode.Name == name && GetDepth(node, elementNode) < lookupDepth)
                {
                    list.Add(elementNode);
                }

                return true;
            };

            var vistor = new Algorithms.TreeVisitors.PreOrderTreeVistor(accept);
            vistor.Visit(node);

            return list;
        }

        private static int GetDepth(SyntaxNode rootNode, SyntaxNode elementNode)
        {
            ISyntaxElement tmp = elementNode;
            int count = 0;
            while (tmp != null && tmp != rootNode)
            {
                count++;
                tmp = tmp.Parent;
            }

            return count;
        }
    }
}
