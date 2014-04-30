using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class ConfDsl : Combinator
    {
        private Combinator matchConfBlock;
        private Combinator matchTabBlock;
        private Combinator matchNameBlock;
        private Combinator matchEndBlock;

        public ConfDsl(Combinator matchConfBlock, Combinator matchTabBlock, Combinator matchNameBlock, Combinator matchEndBlock)
        {
            this.matchConfBlock = matchConfBlock;
            this.matchTabBlock = matchTabBlock;
            this.matchNameBlock = matchNameBlock;
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

            result = matchConfBlock.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchTabBlock.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchNameBlock.Recognizer(result);
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
