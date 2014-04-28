
using xSupermarket.Framework.Model;
using xSupermarket.Framework.Repo;
namespace xSupermarket.Framework.ExDSL
{
    public class ExDSLGenerator
    {
        private TokenBuffer tokenBuffer;
        private Combinator matchSelectDsl;
        private Combinator matchInsertDsl;
        private Combinator matchDeleteDsl;
        private Combinator matchUpdateDsl;
        private Combinator matchTopDsl;
        private Combinator matchSuppDsl;
        private Combinator matchConfDsl;

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
            Combinator matchSelectKeyword = new TerminalParser(TokenType.TT_SELECT);
            Combinator matchInsertKeyword = new TerminalParser(TokenType.TT_INSERT);
            Combinator matchUpdateKeyword = new TerminalParser(TokenType.TT_UPDATE);
            Combinator matchDeleteKeyword = new TerminalParser(TokenType.TT_DELETE);
            Combinator matchEqualKeyword = new TerminalParser(TokenType.TT_EQUAL);
            Combinator matchNotEqualKeyword = new TerminalParser(TokenType.TT_NOTEQUAL);
            Combinator matchLessKeyword = new TerminalParser(TokenType.TT_LESS);
            Combinator matchLargerKeyword = new TerminalParser(TokenType.TT_LARGER);
            Combinator matchNotLessKeyword = new TerminalParser(TokenType.TT_NOTLESS);
            Combinator matchNotLargerKeyword = new TerminalParser(TokenType.TT_NOTLARGER);
            Combinator matchTopKeyword = new TerminalParser(TokenType.TT_TOP);
            Combinator matchSuppKeyword = new TerminalParser(TokenType.TT_SUPP);
            Combinator matchConfKeyword = new TerminalParser(TokenType.TT_CONF);

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
            Combinator matchSelectBlock = new SelectBlock(matchSelectKeyword);
            Combinator matchInsertBlock = new InsertBlock(matchInsertKeyword);
            Combinator matchUpdateBlock = new UpdateBlock(matchUpdateKeyword);
            Combinator matchDeleteBlock = new DeleteBlock(matchDeleteKeyword);
            Combinator matchNumBlock = new NumBlock(TokenType.TT_IDENTIFIER);
            Combinator matchTopBlock = new TopBlock(matchTopKeyword);
            Combinator matchName = new Name(TokenType.TT_IDENTIFIER);
            Combinator matchNameList1 = new NameList1(matchName);
            Combinator matchNameList2 = new NameList2(matchName);
            Combinator matchNameBlock = new NameBlock(matchLeftKeyword, matchNameList1, matchRightKeyword, matchLeftKeyword, matchNameList2, matchRightKeyword);
            Combinator matchSuppBlock = new SuppBlock(matchSuppKeyword);
            Combinator matchConfBlock = new ConfBlock(matchConfKeyword);

            // Entry Point
            matchSelectDsl = new SelectDsl(matchSelectBlock, matchTabBlock, matchCriterionBlock, matchGroupBlock, matchOrderBlock);
            matchInsertDsl = new InsertDsl(matchInsertBlock, matchTabBlock, matchCriterionBlock);
            matchUpdateDsl = new UpdateDsl(matchUpdateBlock, matchTabBlock, matchCriterionBlock);
            matchDeleteDsl = new DeleteDsl(matchDeleteBlock, matchTabBlock, matchCriterionBlock);
            matchTopDsl = new TopDsl(matchTopBlock, matchTabBlock, matchNumBlock);
            matchSuppDsl = new SuppDsl(matchSuppBlock, matchTabBlock, matchNameBlock);
            matchConfDsl = new ConfDsl(matchConfBlock, matchTabBlock, matchNameBlock);
        }

        public object Gen()
        {
            ExObject.Reset();
            bool match = false;
            switch (Token.GetTokenType(tokenBuffer.NextToken().TokenValue))
            {
                case TokenType.TT_SELECT:
                    CombinatorResult selectResult = matchSelectDsl.Recognizer(new CombinatorResult(tokenBuffer, true, new MatchValue(string.Empty)));
                    match = selectResult.MatchStatus;
                    if (match)
                        return ExObject.SelectObject;
                    else
                        return null;
                case TokenType.TT_INSERT:
                    CombinatorResult insertResult = matchInsertDsl.Recognizer(new CombinatorResult(tokenBuffer, true, new MatchValue(string.Empty)));
                    match = insertResult.MatchStatus;
                    if (match)
                        return ExObject.InsertObject;
                    else
                        return null;
                case TokenType.TT_DELETE:
                    CombinatorResult deleteResult = matchDeleteDsl.Recognizer(new CombinatorResult(tokenBuffer, true, new MatchValue(string.Empty)));
                    match = deleteResult.MatchStatus;
                    if (match)
                        return ExObject.DeleteObject;
                    else
                        return null;
                case TokenType.TT_UPDATE:
                    CombinatorResult updateResult = matchUpdateDsl.Recognizer(new CombinatorResult(tokenBuffer, true, new MatchValue(string.Empty)));
                    match = updateResult.MatchStatus;
                    if (match)
                        return ExObject.UpdateObject;
                    else
                        return null;
                case TokenType.TT_TOP:
                    CombinatorResult topResult = matchTopDsl.Recognizer(new CombinatorResult(tokenBuffer, true, new MatchValue(string.Empty)));
                    match = topResult.MatchStatus;
                    if (match)
                        return ExObject.TopObject;
                    else
                        return null;
                case TokenType.TT_CONF:
                    CombinatorResult confResult = matchConfDsl.Recognizer(new CombinatorResult(tokenBuffer, true, new MatchValue(string.Empty)));
                    match = confResult.MatchStatus;
                    if (match)
                        return ExObject.ConfObject;
                    else
                        return null;
                case TokenType.TT_SUPP:
                    CombinatorResult suppResult = matchSuppDsl.Recognizer(new CombinatorResult(tokenBuffer, true, new MatchValue(string.Empty)));
                    match = suppResult.MatchStatus;
                    if (match)
                        return ExObject.SuppObject;
                    else
                        return null;


                default:

                    return null;
            }
        }
    }
}
