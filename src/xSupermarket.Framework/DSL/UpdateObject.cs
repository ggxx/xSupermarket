using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using xSupermarket.Framework.Model;
using xSupermarket.Framework.Repo;

namespace xSupermarket.Framework.DSL
{
    public class UpdateObject
    {
        public UpdateObject()
        {
            this.Criterions = new List<ICriterion>();
            this.Table = string.Empty;
        }

        public IList<ICriterion> Criterions { get; set; }
        public string Table { get; set; }

        public void Execute<T>() where T : class, IModel
        {
            IModel model = ModelFactory.CreateModel<T>();
            foreach (Criterion criterion in this.Criterions)
            {
                PropertyInfo p = typeof(T).GetProperty(criterion.Field);
                p.SetValue(model, criterion.Value, null);
            }
            IRepository<T> repo = RepositoryFactory.CreateRepository<T>();
            repo.Update(model as T);
        }
    }
}
