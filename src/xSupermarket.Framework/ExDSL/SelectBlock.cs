using System.Collections.Generic;
using System.Linq;

namespace xSupermarket.Framework.ExDSL
{
    public class SelectBlock : Combinator
    {
        private Combinator matchSekectKeyword;

        public SelectBlock(Combinator matchSekectKeyword)
        {
            this.matchSekectKeyword = matchSekectKeyword;
        }

        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            if (result.MatchStatus)
            {
                result = matchSekectKeyword.Recognizer(result);
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
            }
            else
            {
                result = new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
            }

            return result;
        }

        public override void Action(params MatchValue[] matchValues)
        {
            // do nothing
        }
    }
}
