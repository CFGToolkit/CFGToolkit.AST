using System;

namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public class PostOrderTreeVistor : TreeVistorBase
    {
        public PostOrderTreeVistor(Func<ISyntaxElement, bool> acceptFactory)
        {
            AcceptFactory = acceptFactory;
        }

        public override void Visit(SyntaxNode node)
        {
            foreach (var child in node.Children)
            {
                Visit(child);
            }

            if (!AcceptFactory(node))
            {
                return;
            }
        }

        public override void Visit(SyntaxToken token)
        {
            AcceptFactory(token);
        }

        public override void Visit(SyntaxNodeOption option)
        {
            if (!option.IsEmpty)
            {
                Visit(option.Inside);
            }

            if (!AcceptFactory(option))
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

            if (!AcceptFactory(many))
            {
                return;
            }
        }
    }
}
