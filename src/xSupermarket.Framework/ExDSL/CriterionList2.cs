using System;
using System.Collections.Generic;
using System.Linq;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionList2 : Combinator
    {
        private Combinator matchRelationship;
        private Combinator matchCriterion;

        public CriterionList2(Combinator matchRelationship, Combinator matchCriterion)
        {
            this.matchRelationship = matchRelationship;
            this.matchCriterion = matchCriterion;
        }
        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            IList<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = inbound;
            result = matchRelationship.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchCriterion.Recognizer(result);
            }
            else
            {
                result = new CombinatorResult(inbound.TokenBuffer, true, new MatchValue(string.Empty));
            }
            if (result.MatchStatus)
            {
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

        }
    }
}
