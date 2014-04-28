using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace xSupermarket.Framework.ExDSL
{
    public class TabBlock : Combinator
    {
        private TokenType tokenType;

        public TabBlock(TokenType tokenType)
        {
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

            if (t != null && t.IsTokenType(tokenType))
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
            ExObject.SelectObject.Table = matchValues[0].MatchString;
            ExObject.InsertObject.Table = matchValues[0].MatchString;
            ExObject.UpdateObject.Table = matchValues[0].MatchString;
            ExObject.DeleteObject.Table = matchValues[0].MatchString;
            ExObject.TopObject.Table = matchValues[0].MatchString;
            ExObject.ConfObject.Table = matchValues[0].MatchString;
            ExObject.SuppObject.Table = matchValues[0].MatchString;
        }
    }
}
