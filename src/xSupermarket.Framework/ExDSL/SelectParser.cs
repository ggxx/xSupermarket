using System.Collections.Generic;

namespace xSupermarket.Framework.ExDSL
{
    public class SelectParser
    {
        private List<Token> CreateTokens(string input)
        {
            List<Token> tokens = new List<Token>();
            string formatInput;
            formatInput = input.Trim().Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("(", " ( ").Replace(")", " ) ").Replace(">", " > ").Replace("<", " < ").Replace("=", " = ");
            while (input.Contains("  "))
            {
                formatInput = formatInput.Replace("  ", " ");
            }
            formatInput = formatInput.Replace("> =", ">=").Replace("< =", "<=");

            string[] values = formatInput.Split(' ');
            foreach (string value in values)
            {
                tokens.Add(new Token(value));
            }
            return tokens;
        }


        public SelectParser(string input)
        {
            List<Token> tokens = CreateTokens(input);

        }

        public void Orders()
        {

        }


        public object GetResult()
        {


            return null;
        }
    }
}
