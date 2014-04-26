
namespace xSupermarket.Framework.DSL
{
    public interface ICriterion
    {
        ICriterion And(ICriterion criterion);

        ICriterion Or(ICriterion criterion);

        string ToWhereClause();
    }
}
