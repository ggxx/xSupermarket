
namespace xSupermarket.Framework.ExDSL
{
    public class ExDSLGenerator
    {
        public ExDSLGenerator(TokenBuffer buffer)
        {


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
            Combinator matchOrderBlock = new OrderBlock(matchAscDesc, matchLeftKeyword, matchOrderList, matchRightKeyword);
            Combinator matchGroup = new Group(TokenType.TT_IDENTIFIER);
            Combinator matchGroupList = new GroupList(matchGroup);
            Combinator matchGroupBlock = new GroupBlock(matchGroupKeyword, matchLeftKeyword, matchGroupList, matchRightKeyword);
            Combinator matchOperation = new Operation(matchEqualKeyword, matchNotEqualKeyword, matchLessKeyword, matchLargerKeyword, matchNotLessKeyword, matchNotLargerKeyword);
            Combinator matchCriterionWithoutLR = new CriterionWithoutLR(matchIdentifierKeyword, matchOperation, matchIdentifierKeyword);
            Combinator matchCriterionWithLR = new CriterionWithLR(matchLeftKeyword, matchCriterionWithoutLR, matchRightKeyword);
            Combinator matchRelationship = new Relationship(matchAndKeyword, matchOrKeyword);
            Combinator matchCriterion = new Criterion(matchCriterionWithLR, matchCriterionWithoutLR);
            Combinator matchCriterionList2 = new CriterionList2(matchRelationship, matchCriterion);
            Combinator matchCriterionList = new CriterionList(matchCriterion, matchCriterionList2);
            Combinator matchCriterionBlock = new CriterionBlock(matchLeftKeyword, matchCriterionList, matchRightKeyword);
            Combinator matchTabBlock = new TabBlock(TokenType.TT_IDENTIFIER);
            Combinator matchSelectBlock = new SelectBlock(matchSekectKeyword);
            Combinator matchSelectDsl = new SelectDsl(matchSelectBlock, matchTabBlock, matchCriterionBlock, matchGroupBlock, matchOrderBlock);


            CombinatorResult selectResult = matchSelectDsl.Recognizer(new CombinatorResult(buffer, true, new MatchValue(string.Empty)));
            if (selectResult.MatchStatus)
            {
                    
            }
        }
    }
}
