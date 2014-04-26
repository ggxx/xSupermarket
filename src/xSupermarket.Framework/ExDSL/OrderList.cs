using System;

namespace xSupermarket.Framework.ExDSL
{
    public class OrderList : OneListCombinator
    {
        private Combinator matchOrder;

        public OrderList(Combinator matchOrder)
        {
            this.matchOrder = matchOrder;
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
