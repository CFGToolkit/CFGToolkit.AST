using System.Collections.Generic;

namespace CFGToolkit.AST
{
    public class SyntaxToken : ISyntaxElement
    {
        public string Value { get; set; }

        public string Name { get; set; }

        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        public ISyntaxElement Parent { get; set; }
    }
}
