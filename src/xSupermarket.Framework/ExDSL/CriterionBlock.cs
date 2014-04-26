
namespace xSupermarket.Framework.ExDSL
{
    public class CriterionBlock : Combinator
    {
        private TokenType tokenTypes1;
        private CriterionList criterionList;
        private TokenType tokenTypes2;
        private Combinator matchLeftKeyword;
        private Combinator matchCriterionList;
        private Combinator matchRightKeyword;

        public CriterionBlock(TokenType tokenTypes1, CriterionList criterionList, TokenType tokenTypes2)
        {
            // TODO: Complete member initialization
            this.tokenTypes1 = tokenTypes1;
            this.criterionList = criterionList;
            this.tokenTypes2 = tokenTypes2;
        }

        public CriterionBlock(Combinator matchLeftKeyword, Combinator matchCriterionList, Combinator matchRightKeyword)
        {
            // TODO: Complete member initialization
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchCriterionList = matchCriterionList;
            this.matchRightKeyword = matchRightKeyword;
        }
        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            return null;
        }

        public override void Action(params MatchValue[] matchValues)
        {
            
        }
    }
}
