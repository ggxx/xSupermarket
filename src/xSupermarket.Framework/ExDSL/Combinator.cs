
namespace xSupermarket.Framework.ExDSL
{
    public interface Combinator
    {
        CombinatorResult Recognizer(CombinatorResult inbound);

        void Action(params MatchValue[] matchValues);
    }
}
