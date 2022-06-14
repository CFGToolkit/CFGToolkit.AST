using System.Collections.Generic;

namespace CFGToolkit.AST
{
    public interface ISyntaxElement
    {
        string Name { get; set; }

        ISyntaxElement Parent { get; set; }

        Dictionary<string, object> Attributes { get; set; }
    }
}
