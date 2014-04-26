using System;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionWithLR : Combinator
    {
        private TokenType tokenTypes1;
        private CriterionWithoutLR criterionWithoutLR;
        private TokenType tokenTypes2;
        private Combinator matchLeftKeyword;
        private Combinator matchCriterionWithoutLR;
        private Combinator matchRightKeyword;

        public CriterionWithLR(TokenType tokenTypes1, CriterionWithoutLR criterionWithoutLR, TokenType tokenTypes2)
        {
            // TODO: Complete member initialization
            this.tokenTypes1 = tokenTypes1;
            this.criterionWithoutLR = criterionWithoutLR;
            this.tokenTypes2 = tokenTypes2;
        }

        public CriterionWithLR(Combinator matchLeftKeyword, Combinator matchCriterionWithoutLR, Combinator matchRightKeyword)
        {
            // TODO: Complete member initialization
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchCriterionWithoutLR = matchCriterionWithoutLR;
            this.matchRightKeyword = matchRightKeyword;
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
