namespace CFGToolkit.AST.Visitors.Traversals
{
    public class PrePostOrderTreeTraversal<TBefore, TAfter> : TreeTraversal<(TBefore, TAfter)>
    {
        public PrePostOrderTreeTraversal(IVisitor<ISyntaxElement, TreeTraversalContext, TBefore> before, IVisitor<ISyntaxElement, TreeTraversalContext, TAfter> after)
        {
            Before = before;
            After = after;
        }

        public IVisitor<ISyntaxElement, TreeTraversalContext, TBefore> Before { get; private set; }

        public IVisitor<ISyntaxElement, TreeTraversalContext, TAfter> After { get; private set; }


        public override (TBefore, TAfter) Accept(SyntaxNode element, TreeTraversalContext context)
        {
            var result = Before.Visit(element, context);

            if (context.Continue)
            {
                foreach (var child in element.Children)
                {
                    Accept(child, new TreeTraversalContext { Depth = context.Depth + 1, Parent = element });
                }
            }

            return (result, After.Visit(element, context));
        }

        public override (TBefore, TAfter) Accept(SyntaxNodeOption element, TreeTraversalContext context)
        {
            var result = Before.Visit(element, context);

            if (!element.IsEmpty && context.Continue)
            {
                Accept(element.Inside, new TreeTraversalContext { Depth = context.Depth + 1, Parent = element });
            }

            return (result, After.Visit(element, context));
        }

        public override (TBefore, TAfter) Accept(SyntaxNodeMany element, TreeTraversalContext context)
        {
            var result = Before.Visit(element, context);

            if (context.Continue)
            {
                foreach (var child in element.Repeated)
                {
                    Accept(child, new TreeTraversalContext { Depth = context.Depth + 1, Parent = element });
                }
            }

            return (result, After.Visit(element, context));
        }

        public override (TBefore, TAfter) Accept(SyntaxToken element, TreeTraversalContext context)
        {
            return (Before.Visit(element, context), After.Visit(element, context));
        }
    }
}
