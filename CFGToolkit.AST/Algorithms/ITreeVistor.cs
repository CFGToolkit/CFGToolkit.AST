namespace CFGToolkit.AST.Algorithms
{
    public interface ITreeVistor
    {
        void Visit(SyntaxNode node, int currentDepth);
        void Visit(SyntaxNodeMany many, int currentDepth);
        void Visit(SyntaxNodeOption option, int currentDepth);
        void Visit(SyntaxToken token, int currentDepth);
    }
}