using CFGToolkit.AST.Visitors;
using CFGToolkit.AST.Visitors.Traversals;
using System.Collections.Generic;

namespace CFGToolkit.AST.Providers
{
    public static class NodeProvider
    {
        public static List<SyntaxNode> GetNodes(this SyntaxNode parentNode, string nodeName, int lookupDepth)
        {
            var traversal = new PreOrderTreeTraversal<List<SyntaxNode>>(new NodeFinderVisitor(lookupDepth, nodeName));
            return traversal.Accept(parentNode, new TreeTraversalContext { Depth = 0 });
        }

        public class NodeFinderVisitor : IVisitor<ISyntaxElement, TreeTraversalContext, List<SyntaxNode>>
        {
            private List<SyntaxNode> _elements = new List<SyntaxNode>();

            public NodeFinderVisitor(int lookupDepth, string nodeName)
            {
                LookupDepth = lookupDepth;
                NodeName = nodeName;
            }

            public int LookupDepth { get; }

            public string NodeName { get; }

            public List<SyntaxNode> Visit(ISyntaxElement element, TreeTraversalContext context)
            {
                if (context.Depth > LookupDepth)
                {
                    context.Continue = false;
                    return null;
                }

                if (element is SyntaxNode elementNode && elementNode.Name == NodeName)
                {
                    _elements.Add(elementNode);
                }

                return _elements;
            }
        }
    }
}
