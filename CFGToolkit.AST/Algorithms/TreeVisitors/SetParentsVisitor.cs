namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public class SetParentsVisitor : TreeVistorBase
    {
        public override void Visit(SyntaxNode node)
        {
            if (node?.Children != null)
            {
                foreach (var child in node.Children)
                {
                    child.Parent = node;
                    Visit(child);
                }
            }
        }

        public override void Visit(SyntaxNodeMany many)
        {
            if (many?.Repeated != null)
            {
                foreach (var child in many.Repeated)
                {
                    child.Parent = many;
                    Visit(child);
                }
            }
        }

        public override void Visit(SyntaxNodeOption option)
        {
            if (option?.Inside != null)
            {
                option.Inside.Parent = option;
                Visit(option.Inside);
            }
        }

        public override void Visit(SyntaxToken token)
        {
        }
    }
}
