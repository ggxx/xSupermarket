using System.Collections.Generic;
using System.Linq;

namespace xSupermarket.Framework.ExDSL
{
    public class TokenBuffer
    {
        private List<Token> tokens;

        public TokenBuffer(List<Token> tokens)
        {
            this.tokens = tokens;
        }
        public Token NextToken()
        {
            return tokens[0];
        }

        public List<Token> MakePoppedTokenList()
        {
            Token[] array = new Token[tokens.Count - 1];
            tokens.CopyTo(0, array, 1, tokens.Count - 1);
            return array.ToList();
        }

        public void PopToken()
        {
            tokens.RemoveAt(0);
        }
    }
}
