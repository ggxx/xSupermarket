using System.Collections.Generic;

namespace xSupermarket.Framework.ExDSL
{
    public class ExDSLParser
    {
        public List<Token> Tokens { get; private set; }

        public ExDSLParser(string input)
        {
            CreateTokens(input);
        }

        private void CreateTokens(string input)
        {
            Tokens = new List<Token>();
            string formatInput;
            formatInput = input.Trim().Replace("\r", " ").Replace("\n", " ").Replace("\t", " ").Replace("(", " ( ").Replace(")", " ) ").Replace(">", " > ").Replace("<", " < ").Replace("=", " = ");
            while (formatInput.Contains("  "))
            {
                formatInput = formatInput.Replace("  ", " ");
            }
            formatInput = formatInput.Replace("> =", ">=").Replace("< =", "<=");

            string[] values = formatInput.Split(' ');
            foreach (string value in values)
            {
                Tokens.Add(new Token(value));
            }
        }
    }
}
