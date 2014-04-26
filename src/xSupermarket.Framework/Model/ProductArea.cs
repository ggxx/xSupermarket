using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.Model
{
    public class ProductArea : IModel
    {
        public const string ID = "ProductArea.Id";
        public const string NAME = "ProductArea.Name";

        public string Id { get; set; }
        public string Name { get; set; }
        public object GetValue(string fieldName)
        {
            switch (fieldName)
            {
                case NAME:
                    return this.Name;
                case ID:
                    return this.Id;
                default:
                    return null;
            }
        }
        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductArea)
            {
                ProductArea k = obj as ProductArea;
                return k.GetHashCode() == this.GetHashCode();
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return this.Name.CompareTo((obj as ProductArea).Name);
        }
    }
}
