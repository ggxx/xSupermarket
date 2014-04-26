using System.Data.SQLite;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.Repo
{
    public class ProductAreaRepository : AbstractRepository<ProductArea>
    {
        private static readonly string SELECT = "select * from ProductArea";
        private static readonly string DELETE = "delete from ProductArea";
        private static readonly string INSERT = "insert into ProductArea(Id, Name) values(:Id, :Name)";
        private static readonly string UPDATE = "update ProductArea set Name=:Name where Id = :Id";

        protected override SQLiteParameter[] GetUpdateSqlParameters(ProductArea model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Id", model.Id),
                new SQLiteParameter("Name", model.Name)
            };
        }

        protected override SQLiteParameter[] GetInsertSqlParameters(ProductArea model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Id", model.Id),
                new SQLiteParameter("Name", model.Name)
            };
        }

        protected override ProductArea CreateModel(SQLiteDataReader dr)
        {
            ProductArea productArea = new ProductArea();
            productArea.Id = TypeHelper.ToString(dr["Id"]);
            productArea.Name = TypeHelper.ToString(dr["Name"]);
            return productArea;
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
