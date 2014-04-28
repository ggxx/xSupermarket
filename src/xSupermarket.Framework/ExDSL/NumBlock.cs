using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class NumBlock : Combinator
    {
        private TokenType tokenType;

        public NumBlock(TokenType tokenType)
        {
            // TODO: Complete member initialization
            this.tokenType = tokenType;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result;
            TokenBuffer tokens = inbound.TokenBuffer;
            Token t = tokens.NextToken();

            if (t.IsTokenType(tokenType))
            {
                TokenBuffer outTokens = new TokenBuffer(tokens.MakePoppedTokenList());
                result = new CombinatorResult(outTokens, true, new MatchValue(t.TokenValue));
                Action(result.MatchValue);
            }
            else
            {
                result = new CombinatorResult(tokens, false, new MatchValue(string.Empty));
            }

            return result;
        }

        public void Action(params MatchValue[] matchValues)
        {
            Debug.Assert(matchValues.Length == 1);
            ExObject.TopObject.Number = int.Parse(matchValues[0].MatchString);
        }
    }
}
