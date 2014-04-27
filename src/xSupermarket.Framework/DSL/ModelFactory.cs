using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.DSL
{
    public class ModelFactory
    {
        public static IModel CreateModel(string table)
        {
            switch (table)
            {
                case Category.TABLE:
                    return new Category();
                default:
                    return null;
            }
        }
    }
}
