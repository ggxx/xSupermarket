using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class UpdateDsl : Combinator
    {
        private Combinator matchUpdateBlock;
        private Combinator matchTabBlock;
        private Combinator matchCriterionBlock;
        private Combinator matchEndBlock;

        public UpdateDsl(Combinator matchUpdateBlock, Combinator matchTabBlock, Combinator matchCriterionBlock, Combinator matchEndBlock)
        {
            this.matchUpdateBlock = matchUpdateBlock;
            this.matchTabBlock = matchTabBlock;
            this.matchCriterionBlock = matchCriterionBlock;
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


            result = matchUpdateBlock.Recognizer(result);
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
