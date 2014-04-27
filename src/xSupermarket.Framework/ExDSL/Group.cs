using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace xSupermarket.Framework.ExDSL
{
    public class Group : Combinator
    {
        private TokenType tokenTypes;

        public Group(TokenType tokenTypes)
        {
            this.tokenTypes = tokenTypes;
        }

        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result;
            TokenBuffer tokens = inbound.TokenBuffer;
            Token t = tokens.NextToken();

            if (t.IsTokenType(tokenTypes))
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

        public override void Action(params MatchValue[] matchValues)
        {
            Debug.Assert(matchValues.Length == 1);
            ExSelectObject.SelectObject.GroupFields.Add(matchValues[0].MatchString);
        }
    }
}
