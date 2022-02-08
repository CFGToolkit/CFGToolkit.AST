namespace CFGToolkit.AST.Visitors.Traversals
{
    public class PostOrderTreeTraversal<TResult> : TreeTraversal<TResult>
    {
        public PostOrderTreeTraversal(IVisitor<ISyntaxElement, TreeTraversalContext, TResult> visitor)
        {
            Visitor = visitor;
        }

        public IVisitor<ISyntaxElement, TreeTraversalContext, TResult> Visitor { get; private set; }

        public override TResult Accept(SyntaxNode element, TreeTraversalContext context)
        {
            foreach (var child in element.Children)
            {
                Accept(child, new TreeTraversalContext { Depth = context.Depth + 1, Parent = element });
            }

            var result = Visitor.Visit(element, context);
            return result;
        }

        public override TResult Accept(SyntaxNodeOption element, TreeTraversalContext context)
        {
            if (!element.IsEmpty)
            {
                Accept(element.Inside, new TreeTraversalContext { Depth = context.Depth + 1, Parent = element });
            }

            var result = Visitor.Visit(element, context);
            return result;
        }

        public override TResult Accept(SyntaxNodeMany element, TreeTraversalContext context)
        {
            foreach (var child in element.Repeated)
            {
                Accept(child, new TreeTraversalContext { Depth = context.Depth + 1, Parent = element });
            }

            var result = Visitor.Visit(element, context);
            return result;
        }

        public override TResult Accept(SyntaxToken element, TreeTraversalContext context)
        {
            return Visitor.Visit(element, context);
        }
    }
}
