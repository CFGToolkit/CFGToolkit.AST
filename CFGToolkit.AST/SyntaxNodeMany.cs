using System.Collections.Generic;

namespace CFGToolkit.AST
{
    public class SyntaxNodeMany : ISyntaxElement
    {
        public SyntaxNodeMany(string name, IEnumerable<ISyntaxElement> repeated)
        {
            Repeated = new List<ISyntaxElement>(repeated) ?? throw new System.ArgumentNullException(nameof(repeated));
            Name = name;
        }

        public List<ISyntaxElement> Repeated { get; }

        public string Name { get; set; }

        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
        
        public ISyntaxElement Parent { get; set; }
    }
}
