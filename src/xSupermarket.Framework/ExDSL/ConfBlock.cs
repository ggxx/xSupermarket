using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class ConfBlock : Combinator
    {
        private Combinator matchConfKeyword;

        public ConfBlock(Combinator matchConfKeyword)
        {
            this.matchConfKeyword = matchConfKeyword;
        }
        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            if (result.MatchStatus)
            {
                result = matchConfKeyword.Recognizer(result);
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
