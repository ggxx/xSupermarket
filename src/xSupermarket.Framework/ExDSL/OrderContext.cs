using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class OrderContext : Combinator
    {
        private Combinator matchAscDesc;
        private Combinator matchLeftKeyword;
        private Combinator matchOrderList;
        private Combinator matchRightKeyword;

        public OrderContext(Combinator matchAscDesc, Combinator matchLeftKeyword, Combinator matchOrderList, Combinator matchRightKeyword)
        {
            // TODO: Complete member initialization
            this.matchAscDesc = matchAscDesc;
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchOrderList = matchOrderList;
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
