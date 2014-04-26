using System.Collections.Generic;
using System.Linq;

namespace xSupermarket.Framework.ExDSL
{
    public class ListCombinator : Combinator
    {
        private Combinator production;

        public ListCombinator(Combinator production)
        {
            this.production = production;
        }

        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }
            CombinatorResult latestResult = inbound;
            MatchValue[] returnValues;
            IList<MatchValue> results = new List<MatchValue>();
            while (latestResult.MatchStatus)
            {
                latestResult = production.Recognizer(latestResult);
                if (latestResult.MatchStatus)
                {
                    results.Add(latestResult.MatchValue);
                }
            }
            if (results.Count > 0)
            {
                //matched something
                returnValues = results.ToArray();
                Action(returnValues);
                latestResult = new CombinatorResult(latestResult.TokenBuffer, true, new MatchValue(string.Empty));
            }
            return (latestResult);
        }

        public override void Action(params MatchValue[] matchValues)
        {
            
        }
    }
}
