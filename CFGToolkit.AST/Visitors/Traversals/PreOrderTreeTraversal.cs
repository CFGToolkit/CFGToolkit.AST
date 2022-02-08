namespace CFGToolkit.AST.Visitors.Traversals
{
    public class PreOrderTreeTraversal<TResult> : TreeTraversal<TResult>
    {
        public PreOrderTreeTraversal(IVisitor<ISyntaxElement, TreeTraversalContext, TResult> vistor)
        {
            Visitor = vistor;
        }

        public IVisitor<ISyntaxElement, TreeTraversalContext, TResult> Visitor { get; private set; }

        public override TResult Accept(SyntaxNode element, TreeTraversalContext context)
        {
            var result = Visitor.Visit(element, context);

            if (context.Continue)
            {
                foreach (var child in element.Children)
                {
                    Accept(child, new TreeTraversalContext { Depth = context.Depth + 1, Parent = element });
                }
            }

            return result;
        }

        public override TResult Accept(SyntaxNodeOption element, TreeTraversalContext context)
        {
            var result = Visitor.Visit(element, context);

            if (!element.IsEmpty && context.Continue)
            {
                Accept(element.Inside, new TreeTraversalContext { Depth = context.Depth + 1, Parent = element });
            }

            return result;
        }

        public override TResult Accept(SyntaxNodeMany element, TreeTraversalContext context)
        {
            var result = Visitor.Visit(element, context);

            if (context.Continue)
            {
                foreach (var child in element.Repeated)
                {
                    Accept(child, new TreeTraversalContext { Depth = context.Depth + 1, Parent = element });
                }
            }

            return result;
        }

        public override TResult Accept(SyntaxToken element, TreeTraversalContext context)
        {
            return Visitor.Visit(element, context);
        }
    }
}
