﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace xSupermarket.Framework.ExDSL
{
    public class Group : Combinator
    {
        private TokenType tokenType;

        public Group(TokenType tokenType)
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
            ExObject.SelectObject.GroupFields.Add(matchValues[0].MatchString);
        }
    }
}
