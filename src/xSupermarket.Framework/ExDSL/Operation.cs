using System;

namespace xSupermarket.Framework.ExDSL
{
    public class Operation : Combinator
    {
        private Combinator matchEqualKeyword;
        private Combinator matchNotEqualKeyword;
        private Combinator matchLessKeyword;
        private Combinator matchLargerKeyword;
        private Combinator matchNotLessKeyword;
        private Combinator matchNotLargerKeyword;

        public Operation(Combinator matchEqualKeyword, Combinator matchNotEqualKeyword, Combinator matchLessKeyword, Combinator matchLargerKeyword, Combinator matchNotLessKeyword, Combinator matchNotLargerKeyword)
        {
            // TODO: Complete member initialization
            this.matchEqualKeyword = matchEqualKeyword;
            this.matchNotEqualKeyword = matchNotEqualKeyword;
            this.matchLessKeyword = matchLessKeyword;
            this.matchLargerKeyword = matchLargerKeyword;
            this.matchNotLessKeyword = matchNotLessKeyword;
            this.matchNotLargerKeyword = matchNotLargerKeyword;
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
