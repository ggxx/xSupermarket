
namespace xSupermarket.Framework.Model
{
    public class Marketbasket : IModel
    {
        public const string ID = "Marketbasket.Id";
        public const string PRODUCTS = "Marketbasket.Product";

        public string Id { get; set; }

        public Product Product { get; set; }

        public object GetValue(string fieldName)
        {
            switch (fieldName)
            {
                case ID:
                    return this.Id;
                case PRODUCTS:
                    return this.Product;
                default:
                    return null;
            }
        }

        public int CompareTo(object obj)
        {
            return this.Id.CompareTo((obj as Marketbasket).Id);
        }
    }
}
