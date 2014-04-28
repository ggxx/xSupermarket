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
            this.matchAscDesc = matchAscDesc;
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchOrderList = matchOrderList;
            this.matchRightKeyword = matchRightKeyword;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            result = matchAscDesc.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchLeftKeyword.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchOrderList.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchRightKeyword.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
            }
            else
            {
                result = new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
            }

            return result;
        }

        public void Action(params MatchValue[] matchValues)
        {
            // do nothing
        }
    }
}
