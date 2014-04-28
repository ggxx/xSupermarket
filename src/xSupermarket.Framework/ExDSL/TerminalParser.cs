using System.Diagnostics;

namespace xSupermarket.Framework.ExDSL
{
    public class TerminalParser : Combinator
    {
        private TokenType tokenMatch;

        public TerminalParser(TokenType match)
        {
            this.tokenMatch = match;
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

            if (t.IsTokenType(tokenMatch))
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

            switch (tokenMatch)
            {
                case TokenType.TT_SELECT:
                    return;
                case TokenType.TT_IDENTIFIER:
                    return;
            }

            //ExDSLHelper.AddTerminalField(matchValues[0]);
        }
    }
}
