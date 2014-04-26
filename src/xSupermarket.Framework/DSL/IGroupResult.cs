using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.DSL
{
    public interface IGroupResult<T> : IResult<T>  where T : IModel
    {
        IList<GroupRecord<T>> ListGroupingResult();
    }
}
