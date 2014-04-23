using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.Model
{
    public class Product : IModel
    {
        public const string NAME = "Product.Name";
        public const string PRICE = "Product.Price";
        public const string COST = "Product.Cost";
        public const string PRODUCT_AREA = "Product.ProductArea";
        public const string SECTION = "Product.Section";
        public const string CATEGORY = "Product.Category";
        public const string SALES = "Product.Sales";

        public string Name { get; set; }
        public float? Price { get; set; }
        public float? Cost { get; set; }
        public ProductArea ProductArea { get; set; }
        public Section Section { get; set; }
        public Category Category { get; set; }
        public int? Sales { get; set; }

        public object GetValue(string fieldName)
        {
            switch (fieldName)
            {
                case NAME:
                    return this.Name;
                case PRICE:
                    return this.Price;
                case COST:
                    return this.Cost;
                case PRODUCT_AREA:
                    return this.ProductArea;
                case SECTION:
                    return this.Section;
                case CATEGORY:
                    return this.Category;
                case SALES:
                    return this.Sales;
                default:
                    return null;
            }
        }
    }
}
