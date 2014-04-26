using System;

namespace xSupermarket.Framework.ExDSL
{
    public class Group : Combinator
    {
        private TokenType tokenTypes;
        private Combinator matchIdentifierKeyword;

        public Group(TokenType tokenTypes)
        {
            // TODO: Complete member initialization
            this.tokenTypes = tokenTypes;
        }

        public Group(Combinator matchIdentifierKeyword)
        {
            // TODO: Complete member initialization
            this.matchIdentifierKeyword = matchIdentifierKeyword;
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
