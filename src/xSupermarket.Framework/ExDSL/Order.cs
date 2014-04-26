using System.Diagnostics;

namespace xSupermarket.Framework.ExDSL
{
    public class Order : TerminalParser
    {
        public Order(TokenType tokenType)
            : base(tokenType)
        {
        }

        public override void Action(params MatchValue[] matchValues)
        {
            Debug.Assert(matchValues.Length == 1);
            //ExDSLHelper.AddOrderField(matchValues[0]);
        }
    }
}
