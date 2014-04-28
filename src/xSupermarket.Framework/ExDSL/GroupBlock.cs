using System;
using System.Collections.Generic;

namespace xSupermarket.Framework.ExDSL
{
    public class GroupBlock : Combinator
    {
        private Combinator matchGroupContext;


        public GroupBlock(Combinator matchGroupContext)
        {
            this.matchGroupContext = matchGroupContext;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            List<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = inbound;
            result = matchGroupContext.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
            }
            else
            {
                // match nothing is allowed
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
