using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.DSL
{
    public class Criterion : ICriterion
    {
        string field;
        Operator oper;
        object value;

        public Criterion(string field, Operator oper, object value)
        {
            this.field = field;
            this.oper = oper;
            this.value = value;
        }

        public ICriterion And(ICriterion c2)
        {
            return new CriterionPair(this, c2, Relationship.And);
        }

        public ICriterion Or(ICriterion c2)
        {
            return new CriterionPair(this, c2, Relationship.Or);
        }

        public string ToWhereClause()
        {
            return string.Format(" {0} {1} {2} ", field, ConvertToString(oper), value is String ? string.Format("'{0}'", value) : value);
        }

        private string ConvertToString(Operator oper)
        {
            switch (oper)
            {
                case Operator.Equal:
                    return "=";
                case Operator.NotEqual:
                    return "<>";
                default:
                    throw new InvalidCastException("Error Operator!");
            }
        }
    }

    public enum Operator
    {
        Equal,
        NotEqual
    }
}
