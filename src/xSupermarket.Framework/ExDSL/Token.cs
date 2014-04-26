
namespace xSupermarket.Framework.ExDSL
{
    public class Token
    {
        const string KW_TOP = "TOP";
        const string KW_SUPP = "SUPP";
        const string KW_CONF = "CONF";
        const string KW_INSERT = "INSERT";
        const string KW_UPDATE = "UPDATE";
        const string KW_DELETE = "DELETE";
        const string KW_SELECT = "SELECT";
        const string KW_AND = "AND";
        const string KW_OR = "OR";
        const string KW_LEFT = "(";
        const string KW_RIGHT = ")";
        const string KW_EQUAL = "=";
        const string KW_NOTEQUAL = "<>";
        const string KW_LARGER = ">";
        const string KW_NOTLARGER = "<=";
        const string KW_LESS = "<";
        const string KW_NOTLESS = ">=";

        public Token(string value)
        {
            this.TokenValue = value;
        }

        public string TokenValue { get; private set; }
        public bool IsTokenType(TokenType tokenMatch)
        {
            return tokenMatch == GetTokenType(this.TokenValue);
        }

        private static TokenType GetTokenType(string text)
        {
            switch (text)
            {
                case KW_AND:
                    return TokenType.TT_AND;
                case KW_CONF:
                    return TokenType.TT_CONF;
                case KW_DELETE:
                    return TokenType.TT_DELETE;
                case KW_INSERT:
                    return TokenType.TT_INSERT;
                case KW_LEFT:
                    return TokenType.TT_LEFT;
                case KW_OR:
                    return TokenType.TT_OR;
                case KW_RIGHT:
                    return TokenType.TT_RIGHT;
                case KW_SELECT:
                    return TokenType.TT_SELECT;
                case KW_SUPP:
                    return TokenType.TT_SUPP;
                case KW_TOP:
                    return TokenType.TT_TOP;
                case KW_UPDATE:
                    return TokenType.TT_UPDATE;
                case KW_EQUAL:
                    return TokenType.TT_EQUAL;
                case KW_NOTEQUAL:
                    return TokenType.TT_NOTEQUAL;
                case KW_LARGER:
                    return TokenType.TT_LARGER;
                case KW_NOTLARGER:
                    return TokenType.TT_NOTLARGER;
                case KW_LESS:
                    return TokenType.TT_LESS;
                case KW_NOTLESS:
                    return TokenType.TT_NOTLESS;
                default:
                    return TokenType.UNKNOWN;
            }
        }
    }
}
