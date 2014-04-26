using System;

namespace xSupermarket.Framework.ExDSL
{
    public class Relationship : Combinator
    {
        private Combinator matchAndKeyword;
        private Combinator matchOrKeyword;

        public Relationship(Combinator matchAndKeyword, Combinator matchOrKeyword)
        {
            // TODO: Complete member initialization
            this.matchAndKeyword = matchAndKeyword;
            this.matchOrKeyword = matchOrKeyword;
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
