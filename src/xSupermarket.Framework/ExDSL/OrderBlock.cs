﻿using System;

namespace xSupermarket.Framework.ExDSL
{
    public class OrderBlock :Combinator
    {
        private Combinator matchAscDesc;
        private Combinator matchLeftKeyword;
        private Combinator matchOrderList;
        private Combinator matchRightKeyword;
        private Combinator matchOrderContext;

        public OrderBlock(Combinator matchAscDesc, Combinator matchLeftKeyword, Combinator matchOrderList, Combinator matchRightKeyword)
        {
            // TODO: Complete member initialization
            this.matchAscDesc = matchAscDesc;
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchOrderList = matchOrderList;
            this.matchRightKeyword = matchRightKeyword;
        }

        public OrderBlock(Combinator matchOrderContext)
        {
            // TODO: Complete member initialization
            this.matchOrderContext = matchOrderContext;
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
