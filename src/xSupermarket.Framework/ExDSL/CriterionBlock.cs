using System.Linq;
using System.Collections.Generic;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionBlock : Combinator
    {
        private Combinator matchLeftKeyword;
        private Combinator matchCriterionList;
        private Combinator matchRightKeyword;

        public CriterionBlock(Combinator matchLeftKeyword, Combinator matchCriterionList, Combinator matchRightKeyword)
        {
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchCriterionList = matchCriterionList;
            this.matchRightKeyword = matchRightKeyword;
        }
        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            if (result.MatchStatus)
            {
                result = matchLeftKeyword.Recognizer(result);
                matchValues.Add(result.MatchValue);
            }
            if (result.MatchStatus)
            {
                result = matchCriterionList.Recognizer(result);
                matchValues.Add(result.MatchValue);
            }
            else
            {
                // match nothing
                return new CombinatorResult(inbound.TokenBuffer, true, new MatchValue(string.Empty));
            }
            if (result.MatchStatus)
            {
                result = matchRightKeyword.Recognizer(result);
                matchValues.Add(result.MatchValue);
            }

            if (result.MatchStatus)
            {
                // matched
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
            // do nothing
        }
    }
}
