using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.Repo
{
    public class SectionRepository : AbstractRepository<Section>
    {
        private static readonly string SELECT = "select * from Section";
        private static readonly string DELETE = "delete from Section";
        private static readonly string INSERT = "insert into Section(Id, Name) values(:Id, :Name)";
        private static readonly string UPDATE = "update Section set Name=:Name where Id = :Id";

        protected override SQLiteParameter[] GetUpdateSqlParameters(Section model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Id", model.Id),
                new SQLiteParameter("Name", model.Name)
            };
        }

        protected override SQLiteParameter[] GetInsertSqlParameters(Section model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Id", model.Id),
                new SQLiteParameter("Name", model.Name)
            };
        }

        protected override Section CreateModel(SQLiteDataReader dr)
        {
            Section section = new Section();
            section.Id = TypeHelper.ToString(dr["Id"]);
            section.Name = TypeHelper.ToString(dr["Name"]);
            return section;
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
