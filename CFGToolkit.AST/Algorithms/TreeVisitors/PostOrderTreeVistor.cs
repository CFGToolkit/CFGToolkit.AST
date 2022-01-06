using System;

namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public class PostOrderTreeVistor : TreeVistorBase
    {
        protected Func<ISyntaxElement, bool> PostAcceptFactory { get; set; }

        public PostOrderTreeVistor(Func<ISyntaxElement, bool> acceptFactory)
        {
            PostAcceptFactory = acceptFactory;
        }

        public override void Visit(SyntaxNode node)
        {
            foreach (var child in node.Children)
            {
                Visit(child);
            }

            if (!PostAcceptFactory(node))
            {
                return;
            }
        }

        public override void Visit(SyntaxToken token)
        {
            PostAcceptFactory(token);
        }

        public override void Visit(SyntaxNodeOption option)
        {
            if (!option.IsEmpty)
            {
                Visit(option.Inside);
            }

            if (!PostAcceptFactory(option))
            {
                return;
            }
        }

        public override void Visit(SyntaxNodeMany many)
        {
            foreach (var instance in many.Repeated)
            {
                Visit(instance);
            }

            if (!PostAcceptFactory(many))
            {
                return;
            }
        }
    }
}
