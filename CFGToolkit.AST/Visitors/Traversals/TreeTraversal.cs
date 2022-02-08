using System;

namespace CFGToolkit.AST.Visitors.Traversals
{
    public abstract class TreeTraversal<TResult> : ITreeTraversal<TResult>
    {
        public TResult Accept(ISyntaxElement element, TreeTraversalContext context)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (element is SyntaxNode)
            {
                return Accept((SyntaxNode)element, context);
            }

            if (element is SyntaxToken)
            {
                return Accept((SyntaxToken)element, context);
            }

            if (element is SyntaxNodeOption)
            {
                return Accept((SyntaxNodeOption)element, context);
            }

            if (element is SyntaxNodeMany)
            {
                return Accept((SyntaxNodeMany)element, context);
            }

            return default;
        }

        public abstract TResult Accept(SyntaxNode element, TreeTraversalContext context);

        public abstract TResult Accept(SyntaxToken element, TreeTraversalContext context);

        public abstract TResult Accept(SyntaxNodeOption element, TreeTraversalContext context);

        public abstract TResult Accept(SyntaxNodeMany element, TreeTraversalContext context);
    }
}
