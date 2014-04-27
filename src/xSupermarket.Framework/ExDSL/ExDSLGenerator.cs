
namespace xSupermarket.Framework.ExDSL
{
    public class ExDSLGenerator
    {
        private TokenBuffer tokenBuffer;
        private Combinator matchSelectDsl;
        private Combinator matchInsertDsl;


        public ExDSLGenerator(ExDSLParser parser)
        {
            this.tokenBuffer = new TokenBuffer(parser.Tokens);

            //Termianl Symbols
            Combinator matchIdentifierKeyword = new TerminalParser(TokenType.TT_IDENTIFIER);
            Combinator matchAscKeyword = new TerminalParser(TokenType.TT_ASC);
            Combinator matchDescKeyword = new TerminalParser(TokenType.TT_DESC);
            Combinator matchLeftKeyword = new TerminalParser(TokenType.TT_LEFT);
            Combinator matchRightKeyword = new TerminalParser(TokenType.TT_RIGHT);
            Combinator matchGroupKeyword = new TerminalParser(TokenType.TT_GROUP);
            Combinator matchAndKeyword = new TerminalParser(TokenType.TT_AND);
            Combinator matchOrKeyword = new TerminalParser(TokenType.TT_OR);
            Combinator matchSekectKeyword = new TerminalParser(TokenType.TT_SELECT);
            Combinator matchEqualKeyword = new TerminalParser(TokenType.TT_EQUAL);
            Combinator matchNotEqualKeyword = new TerminalParser(TokenType.TT_NOTEQUAL);
            Combinator matchLessKeyword = new TerminalParser(TokenType.TT_LESS);
            Combinator matchLargerKeyword = new TerminalParser(TokenType.TT_LARGER);
            Combinator matchNotLessKeyword = new TerminalParser(TokenType.TT_NOTLESS);
            Combinator matchNotLargerKeyword = new TerminalParser(TokenType.TT_NOTLARGER);

            //Non-terminal rules
            Combinator matchOrder = new Order(TokenType.TT_IDENTIFIER);
            Combinator matchOrderList = new OrderList(matchOrder);
            Combinator matchAscDesc = new AscDesc(matchAscKeyword, matchDescKeyword);
            Combinator matchOrderContext = new OrderContext(matchAscDesc, matchLeftKeyword, matchOrderList, matchRightKeyword);
            Combinator matchOrderBlock = new OrderBlock(matchOrderContext);
            Combinator matchGroup = new Group(TokenType.TT_IDENTIFIER);
            Combinator matchGroupList = new GroupList(matchGroup);
            Combinator matchGroupContext = new GroupContext(matchGroupKeyword, matchLeftKeyword, matchGroupList, matchRightKeyword);
            Combinator matchGroupBlock = new GroupBlock(matchGroupContext);
            Combinator matchOperation = new Operation(matchEqualKeyword, matchNotEqualKeyword, matchLessKeyword, matchLargerKeyword, matchNotLessKeyword, matchNotLargerKeyword);
            Combinator matchCriterion = new Criterion(matchIdentifierKeyword, matchOperation, matchIdentifierKeyword);
            Combinator matchCriterionList = new CriterionList(matchCriterion);
            Combinator matchCriterionContext = new CriterionContext(matchLeftKeyword, matchCriterionList, matchRightKeyword);
            Combinator matchCriterionBlock = new CriterionBlock(matchCriterionContext);
            Combinator matchTabBlock = new TabBlock(TokenType.TT_IDENTIFIER);
            Combinator matchSelectBlock = new SelectBlock(matchSekectKeyword);
            matchSelectDsl = new SelectDsl(matchSelectBlock, matchTabBlock, matchCriterionBlock, matchGroupBlock, matchOrderBlock);
        }

        public object Gen()
        {
            ExSelectObject.Reset();
            bool match = false;
            switch (Token.GetTokenType(tokenBuffer.NextToken().TokenValue))
            {
                case TokenType.TT_SELECT:
                    CombinatorResult selectResult = matchSelectDsl.Recognizer(new CombinatorResult(tokenBuffer, true, new MatchValue(string.Empty)));
                    match = selectResult.MatchStatus;
                    if (match)
                        return ExSelectObject.SelectObject;
                    else
                        return null;
                case TokenType.TT_INSERT:
                    return null;
                default:
                    return null;
            }
        }
    }
}
