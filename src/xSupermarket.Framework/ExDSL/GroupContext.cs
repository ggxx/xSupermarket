using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class GroupContext : Combinator
    {
        private Combinator matchGroupKeyword;
        private Combinator matchLeftKeyword;
        private Combinator matchGroupList;
        private Combinator matchRightKeyword;

        public GroupContext(Combinator matchGroupKeyword, Combinator matchLeftKeyword, Combinator matchGroupList, Combinator matchRightKeyword)
        {
            this.matchGroupKeyword = matchGroupKeyword;
            this.matchLeftKeyword = matchLeftKeyword;
            this.matchGroupList = matchGroupList;
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

            result = matchGroupKeyword.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchLeftKeyword.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchGroupList.Recognizer(result);
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

        public override void Action(params MatchValue[] matchValues)
        {
            // do nothing
        }
    }
}
