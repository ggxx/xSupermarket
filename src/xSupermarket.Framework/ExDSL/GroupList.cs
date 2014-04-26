using System;

namespace xSupermarket.Framework.ExDSL
{
    public class GroupList : Combinator
    {
        private Combinator matchGroup;

        public GroupList(Combinator matchGroup)
        {
            // TODO: Complete member initialization
            this.matchGroup = matchGroup;
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
