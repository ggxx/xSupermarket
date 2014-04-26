using System;

namespace xSupermarket.Framework.ExDSL
{
    public class AscDesc : Combinator
    {
        private Combinator matchAscKeyword;
        private Combinator matchDescKeyword;

        public AscDesc(Combinator matchAscKeyword, Combinator matchDescKeyword)
        {
            // TODO: Complete member initialization
            this.matchAscKeyword = matchAscKeyword;
            this.matchDescKeyword = matchDescKeyword;
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
