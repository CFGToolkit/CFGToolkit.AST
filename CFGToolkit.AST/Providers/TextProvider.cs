using System.Linq;

namespace CFGToolkit.AST.Providers
{
    public static class TextProvider
    {
        public static string Text(this SyntaxNode node)
        {
            bool tokenize = node.Attributes.ContainsKey("tokenize");

            var tokens = TokenProvider.GetTokens(node);

            return string.Join(tokenize ? " " : "", tokens.Select(t => t.Value));
        }
    }
}
