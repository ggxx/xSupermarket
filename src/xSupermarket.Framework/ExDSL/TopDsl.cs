using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class TopDsl : Combinator
    {
        private Combinator matchTopBlock;
        private Combinator matchTabBlock;
        private Combinator matchNumBlock;

        public TopDsl(Combinator matchTopBlock, Combinator matchTabBlock, Combinator matchNumBlock)
        {
            this.matchTopBlock = matchTopBlock;
            this.matchTabBlock = matchTabBlock;
            this.matchNumBlock = matchNumBlock;
        }
        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            result = matchTopBlock.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchTabBlock.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchNumBlock.Recognizer(result);
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
