using System;

namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public class PreOrderTreeVistor : TreeVistorBase
    {
        public PreOrderTreeVistor(Func<ISyntaxElement, bool> acceptFactory)
        {
            AcceptFactory = acceptFactory;
        }

        public override void Visit(SyntaxNode node)
        {
            if (!AcceptFactory(node))
            {
                return;
            }
            foreach (var child in node.Children)
            {
                Visit(child);
            }
        }

        public override void Visit(SyntaxToken token)
        {
            AcceptFactory(token);
        }

        public override void Visit(SyntaxNodeOption option)
        {
            if (!AcceptFactory(option))
            {
                return;
            }

            if (!option.IsEmpty)
            {
                Visit(option.Inside);
            }
        }

        public override void Visit(SyntaxNodeMany many)
        {
            if (!AcceptFactory(many))
            {
                return;
            }

            foreach (var instance in many.Repeated)
            {
                Visit(instance);
            }
        }
    }
}
