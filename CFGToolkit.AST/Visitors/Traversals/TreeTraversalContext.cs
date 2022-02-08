namespace CFGToolkit.AST.Visitors.Traversals
{
    public class TreeTraversalContext
    {
        public int Depth { get; set; }

        public ISyntaxElement Parent { get; set; }

        public bool Continue { get; set; } = true;
    }
}
