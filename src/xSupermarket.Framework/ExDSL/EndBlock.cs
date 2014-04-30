using System.Collections.Generic;
using System.Linq;

namespace xSupermarket.Framework.ExDSL
{
    public class EndBlock : Combinator
    {
        private Combinator matchEndKeyword;

        public EndBlock(Combinator matchEndKeyword)
        {
            this.matchEndKeyword = matchEndKeyword;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            if (result.MatchStatus)
            {
                result = matchEndKeyword.Recognizer(result);
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
            }
            else
            {
                result = new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
            }

            return result;
        }

        public void Action(params MatchValue[] matchValues)
        {
            // do nothing
        }
    }
}
