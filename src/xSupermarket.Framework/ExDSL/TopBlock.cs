using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class TopBlock : Combinator
    {
        private Combinator matchTopKeyword;

        public TopBlock(Combinator matchTopKeyword)
        {
            this.matchTopKeyword = matchTopKeyword;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            if (result.MatchStatus)
            {
                result = matchTopKeyword.Recognizer(result);
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
