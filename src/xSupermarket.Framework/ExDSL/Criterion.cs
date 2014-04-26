using System;

namespace xSupermarket.Framework.ExDSL
{
    public class Criterion : Combinator
    {
        private Combinator matchCriterionWithLR;
        private Combinator matchCriterionWithoutLR;

        public Criterion(Combinator matchCriterionWithLR, Combinator matchCriterionWithoutLR)
        {
            // TODO: Complete member initialization
            this.matchCriterionWithLR = matchCriterionWithLR;
            this.matchCriterionWithoutLR = matchCriterionWithoutLR;
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
