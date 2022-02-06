namespace CFGToolkit.AST.Algorithms.TreeVisitors
{
    public class SetParentsVisitor : TreeVistorBase
    {
        public override void Visit(SyntaxNode node, int currentDepth)
        {
            if (node?.Children != null)
            {
                foreach (var child in node.Children)
                {
                    child.Parent = node;
                    Visit(child, currentDepth + 1);
                }
            }
        }

        public override void Visit(SyntaxNodeMany many, int currentDepth)
        {
            if (many?.Repeated != null)
            {
                foreach (var child in many.Repeated)
                {
                    child.Parent = many;
                    Visit(child, currentDepth + 1);
                }
            }
        }

        public override void Visit(SyntaxNodeOption option, int currentDepth)
        {
            if (option?.Inside != null)
            {
                option.Inside.Parent = option;
                Visit(option.Inside, currentDepth + 1);
            }
        }

        public override void Visit(SyntaxToken token, int currentDepth)
        {
        }
    }
}
