using System;

namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public class PreAndPostTreeVistor : TreeVistorBase
    {
        protected Func<ISyntaxElement, int, bool> PreAcceptFactory { get; set; }

        protected Action<ISyntaxElement, int> PostAcceptFactory { get; set; }

        public PreAndPostTreeVistor(Func<ISyntaxElement, int, bool> preAcceptFactory, Action<ISyntaxElement, int> postAcceptFactory)
        {
            PreAcceptFactory = preAcceptFactory;
            PostAcceptFactory = postAcceptFactory;
        }

        public override void Visit(SyntaxNode node, int currentDepth)
        {
            if (!PreAcceptFactory(node, currentDepth))
            {
                return;
            }

            foreach (var child in node.Children)
            {
                Visit(child, currentDepth + 1);
            }

            PostAcceptFactory(node, currentDepth);
        }

        public override void Visit(SyntaxToken token, int currentDepth)
        {
            PreAcceptFactory(token, currentDepth);
            PostAcceptFactory(token, currentDepth);
        }

        public override void Visit(SyntaxNodeOption option, int currentDepth)
        {
            if (!PreAcceptFactory(option, currentDepth))
            {
                return;
            }

            if (!option.IsEmpty)
            {
                Visit(option.Inside, currentDepth + 1);
            }

            PostAcceptFactory(option, currentDepth);
        }

        public override void Visit(SyntaxNodeMany many, int currentDepth)
        {
            if (!PreAcceptFactory(many, currentDepth))
            {
                return;
            }

            foreach (var instance in many.Repeated)
            {
                Visit(instance, currentDepth + 1);
            }

            PostAcceptFactory(many, currentDepth);
        }
    }
}
