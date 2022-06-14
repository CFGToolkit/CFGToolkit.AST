using System.Collections.Generic;

namespace CFGToolkit.AST
{
    public class SyntaxNodeOption : ISyntaxElement
    {
        public bool IsEmpty
        {
            get
            {
                return Inside == null;
            }
        }

        public ISyntaxElement Inside { get; set; }

        public string Name { get; set; }

        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
        
        public ISyntaxElement Parent { get; set; }
    }
}
