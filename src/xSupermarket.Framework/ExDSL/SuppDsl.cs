using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class SuppDsl : Combinator
    {
        private Combinator matchSuppBlock;
        private Combinator matchTabBlock;
        private Combinator matchNameBlock;

        public SuppDsl(Combinator matchSuppBlock, Combinator matchTabBlock, Combinator matchNameBlock)
        {
            this.matchSuppBlock = matchSuppBlock;
            this.matchTabBlock = matchTabBlock;
            this.matchNameBlock = matchNameBlock;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            result = matchSuppBlock.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchTabBlock.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchNameBlock.Recognizer(result);
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
