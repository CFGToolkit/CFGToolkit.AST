namespace CFGToolkit.AST.Algorithms
{
    public interface ITreeVistor
    {
        void Visit(SyntaxNode node);
        void Visit(SyntaxNodeMany many);
        void Visit(SyntaxNodeOption option);
        void Visit(SyntaxToken token);
    }
}