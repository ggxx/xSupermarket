using System;
using System.Collections.Generic;

namespace xSupermarket.Framework.ExDSL
{
    public class OrderBlock :Combinator
    {
        private Combinator matchOrderContext;

        public OrderBlock(Combinator matchOrderContext)
        {
            this.matchOrderContext = matchOrderContext;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            List<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = inbound;
            result = matchOrderContext.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
            }
            else
            {
                // no order block is allowed
                result = new CombinatorResult(inbound.TokenBuffer, true, new MatchValue(string.Empty));
            }

            return result;
        }

        public void Action(params MatchValue[] matchValues)
        {
            // do nothing
        }
    }
}
