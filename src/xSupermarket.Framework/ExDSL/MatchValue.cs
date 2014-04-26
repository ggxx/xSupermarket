
namespace xSupermarket.Framework.ExDSL
{
    public class MatchValue
    {
        public string MatchString { get; private set; }

        public MatchValue(string match)
        {
            this.MatchString = match;
        }
    }
}
