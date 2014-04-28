using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class InsertDsl : Combinator
    {
        private Combinator matchInsertBlock;
        private Combinator matchTabBlock;
        private Combinator matchCriterionBlock;

        public InsertDsl(Combinator matchInsertBlock, Combinator matchTabBlock, Combinator matchCriterionBlock)
        {
            this.matchInsertBlock = matchInsertBlock;
            this.matchTabBlock = matchTabBlock;
            this.matchCriterionBlock = matchCriterionBlock;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();


            result = matchInsertBlock.Recognizer(result);
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
