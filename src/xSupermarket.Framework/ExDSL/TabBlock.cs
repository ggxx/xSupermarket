using System;

namespace xSupermarket.Framework.ExDSL
{
    public class TabBlock : Combinator
    {
        private TokenType tokenTypes;
        private Combinator matchIdentifierKeyword;

        public TabBlock(TokenType tokenTypes)
        {
            // TODO: Complete member initialization
            this.tokenTypes = tokenTypes;
        }

        public TabBlock(Combinator matchIdentifierKeyword)
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
