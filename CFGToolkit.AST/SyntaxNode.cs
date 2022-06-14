using System.Collections.Generic;

namespace CFGToolkit.AST
{
    public class SyntaxNode : ISyntaxElement
    {
        public SyntaxNode(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public ISyntaxElement Parent { get; set; }

        public List<ISyntaxElement> Children { get; set; } = new List<ISyntaxElement>();

        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    }
}
