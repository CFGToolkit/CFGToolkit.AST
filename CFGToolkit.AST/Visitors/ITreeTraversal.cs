using CFGToolkit.AST.Visitors.Traversals;

namespace CFGToolkit.AST.Visitors
{
    public interface ITreeTraversal<TResult>
    {
        TResult Accept(ISyntaxElement element, TreeTraversalContext context);
    }
}
