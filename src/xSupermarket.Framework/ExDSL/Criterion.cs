using System;
using System.Collections.Generic;

namespace xSupermarket.Framework.ExDSL
{
    public class Criterion : Combinator
    {
        private Combinator matchOperation;
        private Combinator matchIdentifierKeyword1;
        private Combinator matchIdentifierKeyword2;


        public Criterion(Combinator matchIdentifierKeyword1, Combinator matchOperation, Combinator matchIdentifierKeyword2)
        {
            this.matchIdentifierKeyword1 = matchIdentifierKeyword1;
            this.matchOperation = matchOperation;
            this.matchIdentifierKeyword2 = matchIdentifierKeyword2;
        }

        public CombinatorResult Recognizer(CombinatorResult inbound)
        {
            if (!inbound.MatchStatus)
            {
                return inbound;
            }

            CombinatorResult result = inbound;
            List<MatchValue> matchValues = new List<MatchValue>();

            result = matchIdentifierKeyword1.Recognizer(result);
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchOperation.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                result = matchIdentifierKeyword2.Recognizer(result);
            }
            if (result.MatchStatus)
            {
                matchValues.Add(result.MatchValue);
                Action(matchValues.ToArray());
            }
            else
            {
                result = new CombinatorResult(inbound.TokenBuffer, false, new MatchValue(string.Empty));
            }

            return result;
        }

        public void Action(params MatchValue[] matchValues)
        {
            DSL.ICriterion ic = new DSL.Criterion(matchValues[0].MatchString, DSL.Criterion.ConvertToOperator(matchValues[1].MatchString), matchValues[2].MatchString);
            ExObject.SelectObject.Criterions.Add(ic);
            ExObject.InsertObject.Criterions.Add(ic);
            ExObject.UpdateObject.Criterions.Add(ic);
            ExObject.DeleteObject.Criterions.Add(ic);
        }
    }
}
