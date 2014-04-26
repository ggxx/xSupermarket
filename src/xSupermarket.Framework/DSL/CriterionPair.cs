using System;

namespace xSupermarket.Framework.DSL
{
    public class CriterionPair : ICriterion
    {
        ICriterion criterion1;
        ICriterion criterion2;
        Relationship relationship;

        public CriterionPair(ICriterion c1, ICriterion c2, Relationship relationship)
        {
            this.criterion1 = c1;
            this.criterion2 = c2;
            this.relationship = relationship;
        }

        public ICriterion And(ICriterion criterion)
        {
            this.criterion1 = this;
            this.criterion2 = criterion;
            this.relationship = Relationship.And;
            return this;
        }

        public ICriterion Or(ICriterion criterion)
        {
            this.criterion1 = this;
            this.criterion2 = criterion;
            this.relationship = Relationship.Or;
            return this;
        }

        public string ToWhereClause()
        {
            return string.Format(" ( {0} {1} {2} ) ", this.criterion1.ToWhereClause(), ConvertToString(this.relationship), this.criterion2.ToWhereClause());
        }

        private string ConvertToString(Relationship relationship)
        {
            switch (relationship)
            {
                case Relationship.And:
                    return "and";
                case Relationship.Or:
                    return "or";
                default:
                    throw new InvalidCastException("Error Operator!");
            }
        }
    }

    public enum Relationship
    {
        And,
        Or
    }
}
