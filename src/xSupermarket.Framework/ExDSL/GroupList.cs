using System;
using System.Collections.Generic;

namespace xSupermarket.Framework.ExDSL
{
    public class GroupList : Combinator
    {
        private Combinator matchGroup;

        public GroupList(Combinator matchGroup)
        {
            this.matchGroup = matchGroup;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            List<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = inbound;

            result = matchGroup.Recognizer(result);
            while (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchGroup.Recognizer(result);
            }

            if (matchValues.Count > 0)
            {
                Action(matchValues.ToArray());
                result = new CombinatorResult(result.TokenBuffer, true, new MatchValue(string.Empty));
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
