using System;
using System.Collections.Generic;

namespace xSupermarket.Framework.ExDSL
{
    public class Operation : Combinator
    {
        private Combinator matchEqualKeyword;
        private Combinator matchNotEqualKeyword;
        private Combinator matchLessKeyword;
        private Combinator matchLargerKeyword;
        private Combinator matchNotLessKeyword;
        private Combinator matchNotLargerKeyword;

        public Operation(Combinator matchEqualKeyword, Combinator matchNotEqualKeyword, Combinator matchLessKeyword, Combinator matchLargerKeyword, Combinator matchNotLessKeyword, Combinator matchNotLargerKeyword)
        {
            this.matchEqualKeyword = matchEqualKeyword;
            this.matchNotEqualKeyword = matchNotEqualKeyword;
            this.matchLessKeyword = matchLessKeyword;
            this.matchLargerKeyword = matchLargerKeyword;
            this.matchNotLessKeyword = matchNotLessKeyword;
            this.matchNotLargerKeyword = matchNotLargerKeyword;
        }

        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            List<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = inbound;

            result = matchEqualKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
                return result;
            }

            result = inbound;
            result = matchNotEqualKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
                return result;
            }

            result = inbound;
            result = matchLessKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
                return result;
            }

            result = inbound;
            result = matchLargerKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
                return result;
            }

            result = inbound;
            result = matchNotLessKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
                return result;
            }

            result = inbound;
            result = matchNotLargerKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
                return result;
            }

            return new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
        }

        public override void Action(params MatchValue[] matchValues)
        {
            // do nothing
        }
    }
}
