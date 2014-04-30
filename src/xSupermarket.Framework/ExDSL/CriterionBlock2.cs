using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class CriterionBlock2 : Combinator
    {
        private Combinator matchLeftKeyword;
        private Combinator matchCriterionList2;
        private Combinator matchRightKeyword;

        public CriterionBlock2(Combinator matchLeftKeyword, Combinator matchCriterionList2, Combinator matchRightKeyword)
        {
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchCriterionList2 = matchCriterionList2;
            this.matchRightKeyword = matchRightKeyword;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            result = matchLeftKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchCriterionList2.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchRightKeyword.Recognizer(result);
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
