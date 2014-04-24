using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.DSL;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.Repo
{
    public interface IRepository<T> where T : IModel
    {
        IResult<T> Find();
        IResult<T> Find(ICriterion criterion);
        void Insert(T model);
        void Update(T model);
        void Delete(ICriterion criterion);
    }
}
