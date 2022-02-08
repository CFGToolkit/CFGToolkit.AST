using CFGToolkit.AST.Visitors.Traversals;
using System;

namespace CFGToolkit.AST.Visitors.Cases
{
    public class SetParentVisitor : IVisitor<ISyntaxElement, TreeTraversalContext, bool>
    {
        public bool Visit(ISyntaxElement element, TreeTraversalContext context)
        {
            return SetParent(element, context);
        }

        private bool SetParent(ISyntaxElement element, TreeTraversalContext context)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            element.Parent = context.Parent;

            return true;
        }
    }
}
