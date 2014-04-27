using System.Linq;
using System.Collections.Generic;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionBlock : Combinator
    {
        private Combinator matchCriterionContext;


        public CriterionBlock(Combinator matchCriterionContext)
        {
            this.matchCriterionContext = matchCriterionContext;
        }
        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            result = matchCriterionContext.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
            }
            else
            {
                // no Block
                result = new CombinatorResult(inbound.TokenBuffer, true, new MatchValue(string.Empty));
            }

            return result;
        }

        public override void Action(params MatchValue[] matchValues)
        {
            // do nothing
        }
    }
}
