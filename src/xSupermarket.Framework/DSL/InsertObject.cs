using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using xSupermarket.Framework.Model;
using xSupermarket.Framework.Repo;

namespace xSupermarket.Framework.DSL
{
    public class InsertObject : DslObject
    {
        public InsertObject()
        {
            this.Criterions = new List<ICriterion>();
            this.Table = string.Empty;
        }

        public IList<ICriterion> Criterions { get; set; }
        public string Table { get; set; }

        public int Execute<T>() where T : class, IModel
        {
            IModel model = ModelFactory.CreateModel<T>();
            foreach (Criterion criterion in this.Criterions)
            {
                PropertyInfo p = typeof(T).GetProperty(criterion.Field);
                p.SetValue(model, criterion.Value, null);
            }
            IRepository<T> repo = RepositoryFactory.CreateRepository<T>();
            repo.Insert(model as T);
            return 0;
        }

        public string GetOutput()
        {
            int result = -1;
            switch (this.Table)
            {
                case Category.TABLE:
                    result = Execute<Category>();
                    break;
                case Employee.TABLE:
                    result = Execute<Employee>();
                    break;
                case Marketbasket.TABLE:
                    result = Execute<Marketbasket>();
                    break;
                case Product.TABLE:
                    result = Execute<Product>();
                    break;
                case ProductArea.TABLE:
                    result = Execute<ProductArea>();
                    break;
                case Section.TABLE:
                    result = Execute<Section>();
                    break;
            }
            if (result == 0)
            {
                return "OK";
            }
            else
            {
                return "Error";
            }
        }
    }
}
