using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class NameBlock : Combinator
    {
        private Combinator matchLeftKeyword1;
        private Combinator matchNameList1;
        private Combinator matchRightKeyword1;
        private Combinator matchLeftKeyword2;
        private Combinator matchNameList2;
        private Combinator matchRightKeyword2;

        public NameBlock(Combinator matchLeftKeyword1, Combinator matchNameList1, Combinator matchRightKeyword1, Combinator matchLeftKeyword2, Combinator matchNameList2, Combinator matchRightKeyword2)
        {
            this.matchLeftKeyword1 = matchLeftKeyword1;
            this.matchNameList1 = matchNameList1;
            this.matchRightKeyword1 = matchRightKeyword1;
            this.matchLeftKeyword2 = matchLeftKeyword2;
            this.matchNameList2 = matchNameList2;
            this.matchRightKeyword2 = matchRightKeyword2;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            result = matchLeftKeyword1.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchNameList1.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchRightKeyword1.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchLeftKeyword2.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchNameList2.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchRightKeyword2.Recognizer(result);
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
