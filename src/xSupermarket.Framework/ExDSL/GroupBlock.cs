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

        public override CombinatorResult Recognizer(CombinatorResult inbound)
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
                result = new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
            }

            return result;
        }

        public override void Action(params MatchValue[] matchValues)
        {

        }
    }
}
