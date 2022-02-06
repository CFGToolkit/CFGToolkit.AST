using System;

namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public class PostOrderTreeVistor : TreeVistorBase
    {
        protected Func<ISyntaxElement, int, bool> PostAcceptFactory { get; set; }

        public PostOrderTreeVistor(Func<ISyntaxElement, int, bool> acceptFactory)
        {
            PostAcceptFactory = acceptFactory;
        }

        public override void Visit(SyntaxNode node, int currentDepth)
        {
            foreach (var child in node.Children)
            {
                Visit(child, currentDepth + 1);
            }

            if (!PostAcceptFactory(node, currentDepth))
            {
                return;
            }
        }

        public override void Visit(SyntaxToken token, int currentDepth)
        {
            PostAcceptFactory(token, currentDepth);
        }

        public override void Visit(SyntaxNodeOption option, int currentDepth)
        {
            if (!option.IsEmpty)
            {
                Visit(option.Inside, currentDepth + 1);
            }

            if (!PostAcceptFactory(option, currentDepth))
            {
                return;
            }
        }

        public override void Visit(SyntaxNodeMany many, int currentDepth)
        {
            foreach (var instance in many.Repeated)
            {
                Visit(instance, currentDepth + 1);
            }

            if (!PostAcceptFactory(many, currentDepth))
            {
                return;
            }
        }
    }
}
