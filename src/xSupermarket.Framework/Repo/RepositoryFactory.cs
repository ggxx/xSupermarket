using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.Repo
{
    public class RepositoryFactory
    {
        public static IRepository<T> CreateRepository<T>() where T : IModel
        {
            if (typeof(T) == typeof(Category))
            {
                return (IRepository<T>)new CategoryRepository();
            }
            else if (typeof(T) == typeof(Employee))
            {
                return (IRepository<T>)new EmployeeRepository();
            }
            else if (typeof(T) == typeof(Marketbasket))
            {
                return (IRepository<T>)new MarketbasketRepository();
            }
            else if (typeof(T) == typeof(Product))
            {
                return (IRepository<T>)new ProductRepository();
            }
            else if (typeof(T) == typeof(ProductArea))
            {
                return (IRepository<T>)new ProductAreaRepository();
            }
            else if (typeof(T) == typeof(Section))
            {
                return (IRepository<T>)new SectionRepository();
            }
            else
            {
                return null;
            }
        }
    }
}
