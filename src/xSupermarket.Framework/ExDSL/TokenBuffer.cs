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
            if (tokens.Count > 0)
            {
                return tokens[0];
            }
            else
            {
                return null;
            }
        }

        public List<Token> MakePoppedTokenList()
        {
            if (tokens.Count > 1)
            {
                Token[] array = new Token[tokens.Count - 1];
                tokens.CopyTo(1, array, 0, tokens.Count - 1);
                return array.ToList();
            }
            else
            {
                return new List<Token>();
            }
        }

        public void PopToken()
        {
            if (tokens.Count > 0)
            {
                tokens.RemoveAt(0);
            }
        }
    }
}
