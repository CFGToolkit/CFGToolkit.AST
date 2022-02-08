namespace CFGToolkit.AST.Visitors
{
    public interface IVisitor<TElement, TContext, TResult>
    {
        TResult Visit(TElement element, TContext context);
    }
}
