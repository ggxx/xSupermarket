using System.Collections.Generic;
using System.Linq;

namespace xSupermarket.Framework.ExDSL
{
    public class SelectDsl : Combinator
    {
        private Combinator matchSelectBlock;
        private Combinator matchTabBlock;
        private Combinator matchCriterionBlock;
        private Combinator matchGroupBlock;
        private Combinator matchOrderBlock;
        private Combinator matchEndBlock;

        public SelectDsl(Combinator matchSelectBlock, Combinator matchTabBlock, Combinator matchCriterionBlock, Combinator matchGroupBlock, Combinator matchOrderBlock, Combinator matchEndBlock)
        {
            this.matchSelectBlock = matchSelectBlock;
            this.matchTabBlock = matchTabBlock;
            this.matchCriterionBlock = matchCriterionBlock;
            this.matchGroupBlock = matchGroupBlock;
            this.matchOrderBlock = matchOrderBlock;
            this.matchEndBlock = matchEndBlock;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();


            result = matchSelectBlock.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchTabBlock.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchCriterionBlock.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchGroupBlock.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchOrderBlock.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchEndBlock.Recognizer(result);
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
