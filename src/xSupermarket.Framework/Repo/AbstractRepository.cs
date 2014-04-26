using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using xSupermarket.Framework.DSL;
using xSupermarket.Framework.Model;

namespace xSupermarket.Framework.Repo
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : IModel
    {
        public AbstractRepository()
        {
        }

        public IResult<T> Find()
        {
            IList<T> list = new List<T>();
            using (SQLiteDataReader dr = SQLiteDbHelper.ExecuteReader(SQLiteDbHelper.ConnectionString, CommandType.Text, GetSelectSql()))
            {
                while (dr.Read())
                {
                    list.Add(CreateModel(dr));
                }
            }
            return new Result<T>(list);
        }

        public IResult<T> Find(ICriterion criterion)
        {
            if (criterion == null)
            {
                return Find();
            }

            string sql = GetSelectSql();
            string whereClause = criterion.ToWhereClause();
            if (!string.IsNullOrWhiteSpace(whereClause))
            {
                sql = sql + " where " + whereClause;
            }

            IList<T> list = new List<T>();
            using (SQLiteDataReader dr = SQLiteDbHelper.ExecuteReader(SQLiteDbHelper.ConnectionString, CommandType.Text, sql))
            {
                while (dr.Read())
                {
                    list.Add(CreateModel(dr));
                }
            }
            return new Result<T>(list);
        }

        public void Insert(T model)
        {
            SQLiteParameter[] pars = GetInsertSqlParameters(model);
            SQLiteDbHelper.ExecuteNonQuery(SQLiteDbHelper.ConnectionString, CommandType.Text, GetInsertSql(), pars);
        }

        public void Update(T model)
        {
            SQLiteParameter[] pars = GetUpdateSqlParameters(model);
            SQLiteDbHelper.ExecuteNonQuery(SQLiteDbHelper.ConnectionString, CommandType.Text, GetUpdateSql(), pars);
        }

        public void Delete(ICriterion criterion)
        {
            if (criterion == null)
            {
                return;
            }

            string sql = GetDeleteSql();
            string whereClause = criterion.ToWhereClause();
            if (!string.IsNullOrWhiteSpace(whereClause))
            {
                sql = sql + " where " + whereClause;
            }

            SQLiteDbHelper.ExecuteNonQuery(SQLiteDbHelper.ConnectionString, CommandType.Text, sql);
        }

        protected abstract SQLiteParameter[] GetUpdateSqlParameters(T model);
        protected abstract SQLiteParameter[] GetInsertSqlParameters(T model);
        protected abstract T CreateModel(SQLiteDataReader dr);
        protected abstract string GetSelectSql();
        protected abstract string GetInsertSql();
        protected abstract string GetUpdateSql();
        protected abstract string GetDeleteSql();
    }
}
