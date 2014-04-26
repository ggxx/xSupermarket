
namespace xSupermarket.Framework.ExDSL
{
    public abstract class Combinator
    {
        public Combinator() { }

        public abstract CombinatorResult Recognizer(CombinatorResult inbound);

        public abstract void Action(params MatchValue[] matchValues);
    }
}
