using System;

namespace xSupermarket.Framework.ExDSL
{
    public class OptionalSequenceCombinator : Combinator
    {
        private Combinator matchAscDesc;
        private Combinator matchLeftKeyword;
        private Combinator matchOrderList;
        private Combinator matchRightKeyword;
        private TokenType tokenTypes1;
        private TokenType tokenTypes2;
        private Combinator matchGroupList;
        private TokenType tokenTypes3;

        public OptionalSequenceCombinator(Combinator matchAscDesc, Combinator matchLeftKeyword, Combinator matchOrderList, Combinator matchRightKeyword)
        {
            // TODO: Complete member initialization
            this.matchAscDesc = matchAscDesc;
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchOrderList = matchOrderList;
            this.matchRightKeyword = matchRightKeyword;
        }

        public OptionalSequenceCombinator(Combinator matchAscDesc, TokenType tokenTypes1, Combinator matchOrderList, TokenType tokenTypes2)
        {
            // TODO: Complete member initialization
            this.matchAscDesc = matchAscDesc;
            this.tokenTypes1 = tokenTypes1;
            this.matchOrderList = matchOrderList;
            this.tokenTypes2 = tokenTypes2;
        }

        public OptionalSequenceCombinator(TokenType tokenTypes1, TokenType tokenTypes2, Combinator matchGroupList, TokenType tokenTypes3)
        {
            // TODO: Complete member initialization
            this.tokenTypes1 = tokenTypes1;
            this.tokenTypes2 = tokenTypes2;
            this.matchGroupList = matchGroupList;
            this.tokenTypes3 = tokenTypes3;
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
