using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.Model
{
    public class Marketbasket : IModel
    {
        public const string ID = "Marketbasket.Id";
        public const string PRODUCTS = "Marketbasket.Products";

        public string Id { get; set; }

        public IList<Product> Products { get; set; }

        public object GetValue(string fieldName)
        {
            switch (fieldName)
            {
                case ID:
                    return this.Id;
                case PRODUCTS:
                    return this.Products;
                default:
                    return null;
            }
        }
    }
}
