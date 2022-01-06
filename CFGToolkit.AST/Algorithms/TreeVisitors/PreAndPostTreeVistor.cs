using System;

namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public class PreAndPostTreeVistor : TreeVistorBase
    {
        protected Func<ISyntaxElement, bool> PreAcceptFactory { get; set; }

        protected Action<ISyntaxElement> PostAcceptFactory { get; set; }

        public PreAndPostTreeVistor(Func<ISyntaxElement, bool> preAcceptFactory, Action<ISyntaxElement> postAcceptFactory)
        {
            PreAcceptFactory = preAcceptFactory;
            PostAcceptFactory = postAcceptFactory;
        }

        public override void Visit(SyntaxNode node)
        {
            if (!PreAcceptFactory(node))
            {
                return;
            }

            foreach (var child in node.Children)
            {
                Visit(child);
            }

            PostAcceptFactory(node);
        }

        public override void Visit(SyntaxToken token)
        {
            PreAcceptFactory(token);
            PostAcceptFactory(token);
        }

        public override void Visit(SyntaxNodeOption option)
        {
            if (!PreAcceptFactory(option))
            {
                return;
            }

            if (!option.IsEmpty)
            {
                Visit(option.Inside);
            }

            PostAcceptFactory(option);
        }

        public override void Visit(SyntaxNodeMany many)
        {
            if (!PreAcceptFactory(many))
            {
                return;
            }

            foreach (var instance in many.Repeated)
            {
                Visit(instance);
            }

            PostAcceptFactory(many);
        }
    }
}
