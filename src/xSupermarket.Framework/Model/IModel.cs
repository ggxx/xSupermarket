using System;

namespace xSupermarket.Framework.Model
{
    public interface IModel : IComparable
    {
        object GetValue(string fieldName);
    }
}
