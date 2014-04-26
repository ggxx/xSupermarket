using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.DSL
{
    public interface IResult<T> where T : IModel
    {
        IList<T> List();
        IResult<T> AscOrderBy(params string[] fields);
        IResult<T> DescOrderBy(params string[] fields);
        IGroupResult<T> GroupBy(params string[] fields);
    }
}
