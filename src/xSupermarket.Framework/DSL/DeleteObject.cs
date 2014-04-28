using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using xSupermarket.Framework.Model;
using xSupermarket.Framework.Repo;

namespace xSupermarket.Framework.DSL
{
    public class DeleteObject
    {
        public DeleteObject()
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

            if (this.Criterions.Count == 1)
            {
                ICriterion criterions = this.Criterions[0];
                repo.Delete(criterions);
            }
            else if (this.Criterions.Count > 1)
            {
                ICriterion criterions = new CriterionPair(this.Criterions[0], this.Criterions[1], Relationship.And);
                for (int i = 2; i < this.Criterions.Count; i++)
                {
                    criterions.And(this.Criterions[i]);
                }
                repo.Delete(criterions);
            }
            else
            {
                throw new InvalidOperationException("Must set a criterion");
            }
        }
    }
}
