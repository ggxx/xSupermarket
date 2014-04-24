using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using xSupermarket.Framework.DSL;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.Repo
{
    public class MarketbasketRepository : AbstractRepository<Marketbasket>
    {
        private static readonly string SELECT = "select * from Marketbasket";
        private static readonly string DELETE = "delete from Marketbasket";
        private static readonly string INSERT = "insert into Marketbasket(Id, Product) values(:Id, :Product)";
        private static readonly string UPDATE = "update Marketbasket set Product=:Product where Id = :Id";

        protected override SQLiteParameter[] GetUpdateSqlParameters(Marketbasket model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Id", model.Id),
                new SQLiteParameter("Product", model.Product.Name)
            };
        }

        protected override SQLiteParameter[] GetInsertSqlParameters(Marketbasket model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Id", model.Id),
                new SQLiteParameter("Product", model.Product.Name)
            };
        }

        protected override Marketbasket CreateModel(SQLiteDataReader dr)
        {
            Marketbasket marketbasket = new Marketbasket();
            marketbasket.Id = TypeHelper.ToString(dr["Id"]);
            marketbasket.Product = new Product() { Name = TypeHelper.ToString(dr["Product"]) };
            return marketbasket;
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
