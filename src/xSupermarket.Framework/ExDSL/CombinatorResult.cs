
namespace xSupermarket.Framework.ExDSL
{
    public class CombinatorResult
    {
        public TokenBuffer TokenBuffer { get; private set; }
        public bool MatchStatus { get; private set; }
        public MatchValue MatchValue { get; private set; }

        public CombinatorResult(TokenBuffer outTokens, bool matchStatus, MatchValue matchValue)
        {
            this.TokenBuffer = outTokens;
            this.MatchStatus = matchStatus;
            this.MatchValue = matchValue;
        }
    }
}
