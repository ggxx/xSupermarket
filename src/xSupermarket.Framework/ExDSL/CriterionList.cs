using System;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionList : Combinator
    {
        private Combinator matchCriterion;
        private Combinator matchCriterionList2;

        public CriterionList(Combinator matchCriterion, Combinator matchCriterionList2)
        {
            // TODO: Complete member initialization
            this.matchCriterion = matchCriterion;
            this.matchCriterionList2 = matchCriterionList2;
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
