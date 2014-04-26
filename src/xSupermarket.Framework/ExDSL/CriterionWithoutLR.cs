using System;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionWithoutLR : Combinator
    {
        private TokenType tokenTypes1;
        private TokenType tokenTypes2;
        private TokenType tokenTypes3;
        private Combinator matchIdentifierKeyword1;
        private Combinator matchOperation;
        private Combinator matchIdentifierKeyword2;

        public CriterionWithoutLR(TokenType tokenTypes1, TokenType tokenTypes2, TokenType tokenTypes3)
        {
            // TODO: Complete member initialization
            this.tokenTypes1 = tokenTypes1;
            this.tokenTypes2 = tokenTypes2;
            this.tokenTypes3 = tokenTypes3;
        }

        public CriterionWithoutLR(Combinator matchIdentifierKeyword1, Combinator matchOperation, Combinator matchIdentifierKeyword2)
        {
            // TODO: Complete member initialization
            this.matchIdentifierKeyword1 = matchIdentifierKeyword1;
            this.matchOperation = matchOperation;
            this.matchIdentifierKeyword2 = matchIdentifierKeyword2;
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
