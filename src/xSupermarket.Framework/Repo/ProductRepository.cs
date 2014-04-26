using System.Data.SQLite;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.Repo
{
    public class ProductRepository : AbstractRepository<Product>
    {
        private static readonly string SELECT = "select * from Product";
        private static readonly string DELETE = "delete from Product";
        private static readonly string INSERT = "insert into Product(Category, Cost, Name, Price, ProductArea, Sales, Section) values(:Category, :Cost, :Name, :Price, :ProductArea, :Sales, :Section)";
        private static readonly string UPDATE = "update Product set Category=:Category, Cost=:Cost, Price=:Price, ProductArea=:ProductArea, Sales=:Sales, Section=:Section where Name = :Name";

        protected override Product CreateModel(SQLiteDataReader dr)
        {
            Product product = new Product();
            product.Category = new Category() { Id = TypeHelper.ToString(dr["Category"]), Name = TypeHelper.ToString(dr["Category"]) };
            product.Cost = TypeHelper.ToFloatNull(dr["Cost"]);
            product.Name = TypeHelper.ToString(dr["Name"]);
            product.Price = TypeHelper.ToFloatNull(dr["Price"]);
            product.ProductArea = new ProductArea() { Id = TypeHelper.ToString(dr["ProductArea"]), Name = TypeHelper.ToString(dr["ProductArea"]) };
            product.Sales = TypeHelper.ToInt32Null(dr["Sales"]);
            product.Section = new Section() { Id = TypeHelper.ToString(dr["Section"]), Name = TypeHelper.ToString(dr["Section"]) };
            return product;
        }

        protected override SQLiteParameter[] GetUpdateSqlParameters(Product model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Category", model.Category.Id),
                new SQLiteParameter("Cost", model.Cost),
                new SQLiteParameter("Name", model.Name),           
                new SQLiteParameter("Price", model.Price),
                new SQLiteParameter("ProductArea", model.ProductArea.Id),
                new SQLiteParameter("Sales", model.Sales),
                new SQLiteParameter("Section", model.Section.Id)
            };
        }

        protected override SQLiteParameter[] GetInsertSqlParameters(Product model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Category", model.Category.Id),
                new SQLiteParameter("Cost", model.Cost),
                new SQLiteParameter("Name", model.Name),           
                new SQLiteParameter("Price", model.Price),
                new SQLiteParameter("ProductArea", model.ProductArea.Id),
                new SQLiteParameter("Sales", model.Sales),
                new SQLiteParameter("Section", model.Section.Id)
            };
        }

        protected override string GetSelectSql()
        {
            return SELECT;
        }

        protected override string GetInsertSql()
        {
            return INSERT;
        }

        protected override string GetUpdateSql()
        {
            return UPDATE;
        }

        protected override string GetDeleteSql()
        {
            return DELETE;
        }
    }
}
