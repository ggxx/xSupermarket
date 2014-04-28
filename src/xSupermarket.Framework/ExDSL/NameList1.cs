using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.ExDSL
{
    public class NameList1 : Combinator
    {
        private Combinator matchName;

        public NameList1(Combinator matchName)
        {
            this.matchName = matchName;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            List<MatchValue> matchValues = new List<MatchValue>();
            CombinatorResult result = inbound;

            result = matchName.Recognizer(result);
            while (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchName.Recognizer(result);
            }

            if (matchValues.Count > 0)
            {
                Action(matchValues.ToArray());
                result = new CombinatorResult(result.TokenBuffer, true, new MatchValue(string.Empty));
            }
            else
            {
                // match nothing is not allowed
                result = new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
            }

            return result;
        }

        public void Action(params MatchValue[] matchValues)
        {
            StringBuilder sb = new StringBuilder("");
            foreach (MatchValue matchValue in matchValues)
            {
                sb.Append(matchValue.MatchString);
                sb.Append(" ");
            }
            string name1 = sb.ToString().Trim();
            ExObject.SuppObject.Name1 = name1;
            ExObject.ConfObject.Name1 = name1;
        }
    }
}
