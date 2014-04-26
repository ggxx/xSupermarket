using System;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionList2 : Combinator
    {
        private Combinator matchRelationship;
        private Combinator matchCriterion;

        public CriterionList2(Combinator matchRelationship, Combinator matchCriterion)
        {
            // TODO: Complete member initialization
            this.matchRelationship = matchRelationship;
            this.matchCriterion = matchCriterion;
        }
        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            throw new NotImplementedException();
        }

        public override void Action(params MatchValue[] matchValues)
        {
            throw new NotImplementedException();
        }
    }
}
