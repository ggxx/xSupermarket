using System;

namespace xSupermarket.Framework.ExDSL
{
    public class GroupBlock : Combinator
    {
        private Combinator matchGroupKeyword;
        private Combinator matchLeftKeyword;
        private Combinator matchGroupList;
        private Combinator matchRightKeyword;

        public GroupBlock(Combinator matchGroupKeyword, Combinator matchLeftKeyword, Combinator matchGroupList, Combinator matchRightKeyword)
        {
            // TODO: Complete member initialization
            this.matchGroupKeyword = matchGroupKeyword;
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchGroupList = matchGroupList;
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
