using System;

namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public abstract class TreeVistorBase : ITreeVistor
    {
        protected Func<ISyntaxElement, bool> AcceptFactory { get; set; }

        public void Visit(SyntaxTree tree)
        {
            if (tree is null)
            {
                throw new ArgumentNullException(nameof(tree));
            }

            Visit(tree.Root);
        }

        public void Visit(ISyntaxElement element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (element is SyntaxNode)
            {
                Visit((SyntaxNode)element);
            }

            if (element is SyntaxToken)
            {
                Visit((SyntaxToken)element);
            }

            if (element is SyntaxNodeOption)
            {
                Visit((SyntaxNodeOption)element);
            }

            if (element is SyntaxNodeMany)
            {
                Visit((SyntaxNodeMany)element);
            }
        }

        public abstract void Visit(SyntaxNode node);

        public abstract void Visit(SyntaxNodeMany many);

        public abstract void Visit(SyntaxNodeOption option);

        public abstract void Visit(SyntaxToken token);
    }
}