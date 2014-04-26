using System.Data.SQLite;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.Repo
{
    public class EmployeeRepository : AbstractRepository<Employee>
    {
        private static readonly string SELECT = "select * from Employee";
        private static readonly string DELETE = "delete from Employee";
        private static readonly string INSERT = "insert into Employee(Id, Name, ) values(:Id, :Name)";
        private static readonly string UPDATE = "update Employee set Name=:Name where Id = :Id";

        protected override SQLiteParameter[] GetUpdateSqlParameters(Employee model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Name", model.Name),
                new SQLiteParameter("Sex", model.Sex == Sex.M ? "M" : "F"),
                new SQLiteParameter("Section", model.Section.Name)
            };
        }

        protected override SQLiteParameter[] GetInsertSqlParameters(Employee model)
        {
            return new SQLiteParameter[]
            {
                new SQLiteParameter("Name", model.Name),
                new SQLiteParameter("Sex", model.Sex == Sex.M ? "M" : "F"),
                new SQLiteParameter("Section", model.Section.Name)
            };
        }

        protected override Employee CreateModel(SQLiteDataReader dr)
        {
            Employee employee = new Employee();
            employee.Sex = TypeHelper.ToString(dr["Sex"]) == "M" ? Sex.M : Sex.F;
            employee.Name = TypeHelper.ToString(dr["Name"]);
            employee.Section = new Section() { Id = TypeHelper.ToString(dr["Id"]), Name = TypeHelper.ToString(dr["name"]) };
            return employee;
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
