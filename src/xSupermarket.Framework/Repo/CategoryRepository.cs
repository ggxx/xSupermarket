using System.Data.SQLite;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.Repo
{
    public class CategoryRepository : AbstractRepository<Category>
    {
        private static readonly string SELECT = "select * from Category";
        private static readonly string DELETE = "delete from Category";
        private static readonly string INSERT = "insert into Category(Id, Name) values(:Id, :Name)";
        private static readonly string UPDATE = "update Category set Name=:Name where Id = :Id";

        protected override SQLiteParameter[] GetUpdateSqlParameters(Category model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Id", model.Id),
                new SQLiteParameter("Name", model.Name)
            };
        }

        protected override SQLiteParameter[] GetInsertSqlParameters(Category model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Id", model.Id),
                new SQLiteParameter("Name", model.Name)
            };
        }

        protected override Category CreateModel(SQLiteDataReader dr)
        {
            Category category = new Category();
            category.Id = TypeHelper.ToString(dr["Id"]);
            category.Name = TypeHelper.ToString(dr["Name"]);
            return category;
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
