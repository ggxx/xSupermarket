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
            // TODO: Complete member initialization
            this.matchCriterion = matchCriterion;
        }

        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            IList<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = matchCriterion.Recognizer(inbound); ;
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchCriterionList2.Recognizer(result);
            }
            if (result.MatchStatus)
            {
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
