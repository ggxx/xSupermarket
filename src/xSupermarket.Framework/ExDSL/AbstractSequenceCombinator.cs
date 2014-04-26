
namespace xSupermarket.Framework.ExDSL
{
    public abstract class AbstractSequenceCombinator : Combinator
    {
        private Combinator[] productions;
        private bool isOptional;

        public AbstractSequenceCombinator(bool optional, params Combinator[] productions)
        {
            this.productions = productions;
            this.isOptional = optional;
        }

        public override CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }
            MatchValue[] componentResults = new MatchValue[productions.Length];
            CombinatorResult latestResult = inbound;
            int productionIndex = 0;
            while (latestResult.MatchStatus && productionIndex < productions.Length)
            {
                Combinator p = productions[productionIndex];
                latestResult = p.Recognizer(latestResult);
                componentResults[productionIndex] = latestResult.MatchValue;
                productionIndex++;
            }
            if (latestResult.MatchStatus)
            {
                Action(componentResults);
            }
            else if (isOptional)
            {
                latestResult = new CombinatorResult(inbound.TokenBuffer, true, new MatchValue(string.Empty));
            }
            else
            {
                latestResult = new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
            }
            return (latestResult);
        }
    }
}
