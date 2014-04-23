using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.DSL
{
    public interface IGroupResult<T>  where T : IModel
    {
        IDictionary<GroupKey, IResult<T>> GetGroupingResult();

        IGroupResult<T> GroupBy(params string[] fields);
    }
}
