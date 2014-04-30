using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionList2 : Combinator
    {
        private Combinator matchCriterion2;

        public CriterionList2(Combinator matchCriterion2)
        {
            this.matchCriterion2 = matchCriterion2;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            List<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = inbound;

            result = matchCriterion2.Recognizer(result);
            
            while (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchCriterion2.Recognizer(result);
            }

            if (matchValues.Count > 1)
            {
                Action(matchValues.ToArray());
                result = new CombinatorResult(result.TokenBuffer, true, new MatchValue(string.Empty));
            }
            else
            {
                // at least match once
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
