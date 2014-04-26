using System;

namespace xSupermarket.Framework.ExDSL
{
    public class OrCombinator : Combinator
    {
        private Combinator matchAscKeyword;
        private Combinator matchDescKeyword;
        private TokenType tokenTypes1;
        private TokenType tokenTypes2;

        public OrCombinator(Combinator matchAscKeyword, Combinator matchDescKeyword)
        {
            // TODO: Complete member initialization
            this.matchAscKeyword = matchAscKeyword;
            this.matchDescKeyword = matchDescKeyword;
        }

        public OrCombinator(TokenType tokenTypes1, TokenType tokenTypes2)
        {
            // TODO: Complete member initialization
            this.tokenTypes1 = tokenTypes1;
            this.tokenTypes2 = tokenTypes2;
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
