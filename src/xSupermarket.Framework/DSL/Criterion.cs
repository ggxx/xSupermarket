using System;

namespace xSupermarket.Framework.DSL
{
    public class Criterion : ICriterion
    {
        public string Field { get; private set; }
        public Operator Oper { get; private set; }
        public object Value { get; private set; }

        public Criterion(string field, Operator oper, object value)
        {
            this.Field = field;
            this.Oper = oper;
            this.Value = value;
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
            if (string.IsNullOrWhiteSpace(Field))
            {
                return string.Empty;
            }

            return string.Format(" {0} {1} {2} ", Field, ConvertToString(Oper), Value is String ? string.Format("'{0}'", Value) : Value);
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
