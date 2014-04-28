using System;
using System.Collections.Generic;
using System.Linq;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionList : Combinator
    {
        private Combinator matchCriterion;

        public CriterionList(Combinator matchCriterion)
        {
            this.matchCriterion = matchCriterion;
        }


        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            List<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = inbound;

            result = matchCriterion.Recognizer(result);
            while (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchCriterion.Recognizer(result);
            }

            if (matchValues.Count > 0)
            {
                Action(matchValues.ToArray());
                result = new CombinatorResult(result.TokenBuffer, true, new MatchValue(string.Empty));
            }
            else
            {
                // match nothing is allowed
                result = new CombinatorResult(inbound.TokenBuffer, true, new MatchValue(string.Empty));
            }

            return result;
        }

        public void Action(params MatchValue[] matchValues)
        {
            // do nothing
        }
    }
}
