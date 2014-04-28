using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.Model
{
    public class ModelFactory
    {
        public static IModel CreateModel<T>() where T : class, IModel
        {
            if (typeof(T) == typeof(Category))
            {
                return new Category();
            }
            else if (typeof(T) == typeof(Employee))
            {
                return new Employee();
            }
            else if (typeof(T) == typeof(Marketbasket))
            {
                return new Marketbasket();
            }
            else if (typeof(T) == typeof(Product))
            {
                return new Product();
            }
            else if (typeof(T) == typeof(ProductArea))
            {
                return new ProductArea();
            }
            else if (typeof(T) == typeof(Section))
            {
                return new Section();
            }
            else
            {
                return default(T);
            }
        }
    }
}
