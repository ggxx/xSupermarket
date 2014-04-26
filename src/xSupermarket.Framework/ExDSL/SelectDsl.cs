using System.Collections.Generic;
using System.Linq;

namespace xSupermarket.Framework.ExDSL
{
    public class SelectDsl : Combinator
    {
        //private SelectResult selectResult;
        private Combinator matchSelectBlock;
        private Combinator matchTabBlock;
        private Combinator matchCriterionBlock;
        private Combinator matchGroupBlock;
        private Combinator matchOrderBlock;

        public SelectDsl(Combinator matchSelectBlock, Combinator matchTabBlock, Combinator matchCriterionBlock, Combinator matchGroupBlock, Combinator matchOrderBlock)
        {
            this.matchSelectBlock = matchSelectBlock;
            this.matchTabBlock = matchTabBlock;
            this.matchCriterionBlock = matchCriterionBlock;
            this.matchGroupBlock = matchGroupBlock;
            this.matchOrderBlock = matchOrderBlock;
        }

        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            if (result.MatchStatus)
            {
                result = matchSelectBlock.Recognizer(result);
                matchValues.Add(result.MatchValue);
            }
            if (result.MatchStatus)
            {
                result = matchTabBlock.Recognizer(result);
                matchValues.Add(result.MatchValue);
            }
            if (result.MatchStatus)
            {
                result = matchCriterionBlock.Recognizer(result);
                matchValues.Add(result.MatchValue);
            }
            if (result.MatchStatus)
            {
                result = matchGroupBlock.Recognizer(result);
                matchValues.Add(result.MatchValue);
            }
            if (result.MatchStatus)
            {
                result = matchOrderBlock.Recognizer(result);
                matchValues.Add(result.MatchValue);
            }

            if (result.MatchStatus)
            {
                Action(matchValues.ToArray());
                //result = new CombinatorResult(result.TokenBuffer, true, new MatchValue(string.Empty));
            }
            else
            {
                result = new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
            }

            return result;
        }

        public override void Action(params MatchValue[] matchValues)
        {
            // do nothing
        }
    }
}
