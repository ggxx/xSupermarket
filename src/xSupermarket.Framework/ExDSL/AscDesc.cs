using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace xSupermarket.Framework.ExDSL
{
    public class AscDesc : Combinator
    {
        private Combinator matchAscKeyword;
        private Combinator matchDescKeyword;

        public AscDesc(Combinator matchAscKeyword, Combinator matchDescKeyword)
        {
            this.matchAscKeyword = matchAscKeyword;
            this.matchDescKeyword = matchDescKeyword;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            List<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = inbound;

            result = matchAscKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
                return result;
            }

            result = inbound;
            result = matchDescKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
                return result;
            }

            return new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
        }

        public void Action(params MatchValue[] matchValues)
        {
            Debug.Assert(matchValues.Length == 1);
            ExObject.SelectObject.SetAsc(matchValues[0].MatchString == "ASC");
        }
    }
}
