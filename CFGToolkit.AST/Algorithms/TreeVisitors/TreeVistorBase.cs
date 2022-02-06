using System;

namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public abstract class TreeVistorBase : ITreeVistor
    {
        public void Visit(SyntaxTree tree)
        {
            if (tree is null)
            {
                throw new ArgumentNullException(nameof(tree));
            }

            Visit(tree.Root, 0);
        }

        public void Visit(ISyntaxElement element, int currentDepth)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (element is SyntaxNode)
            {
                Visit((SyntaxNode)element, currentDepth);
            }

            if (element is SyntaxToken)
            {
                Visit((SyntaxToken)element, currentDepth);
            }

            if (element is SyntaxNodeOption)
            {
                Visit((SyntaxNodeOption)element, currentDepth);
            }

            if (element is SyntaxNodeMany)
            {
                Visit((SyntaxNodeMany)element, currentDepth);
            }
        }

        public abstract void Visit(SyntaxNode node, int currentDepth);

        public abstract void Visit(SyntaxNodeMany many, int currentDepth);

        public abstract void Visit(SyntaxNodeOption option, int currentDepth);

        public abstract void Visit(SyntaxToken token, int currentDepth);
    }
}