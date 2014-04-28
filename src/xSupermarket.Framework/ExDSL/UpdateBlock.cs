using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class UpdateBlock : Combinator
    {
        private Combinator matchUpdateKeyword;

        public UpdateBlock(Combinator matchUpdateKeyword)
        {
            this.matchUpdateKeyword = matchUpdateKeyword;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            CombinatorResult result = inbound;
            IList<MatchValue> matchValues = new List<MatchValue>();

            if (result.MatchStatus)
            {
                result = matchUpdateKeyword.Recognizer(result);
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
