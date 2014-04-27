using System;

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

        public static string ConvertToString(Operator oper)
        {
            switch (oper)
            {
                case Operator.Equal:
                    return "=";
                case Operator.NotEqual:
                    return "<>";
                case Operator.Larger:
                    return ">";
                case Operator.Less:
                    return "<";
                case Operator.NotLarger:
                    return "<=";
                case Operator.NotLess:
                    return ">=";
                default:
                    throw new InvalidCastException("Error Operator!");
            }
        }

        public static Operator ConvertToOperator(string oper)
        {
            switch (oper)
            {
                case "=":
                    return Operator.Equal;
                case "<>":
                    return Operator.NotEqual;
                case ">":
                    return Operator.Larger;
                case "<":
                    return Operator.Less;
                case "<=":
                    return Operator.NotLarger;
                case ">=":
                    return Operator.NotLess;
                default:
                    throw new InvalidCastException("Error Operator!");
            }
        }
    }

    public enum Operator
    {
        Equal,
        NotEqual,
        NotLess,
        Larger,
        NotLarger,
        Less
    }
}
