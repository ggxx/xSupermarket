using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace xSupermarket.Framework.Repo
{
    internal sealed class SQLiteDbHelper
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["SQLiteConnectionString"].ConnectionString;

        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(SQLiteTransaction trans, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static int ExecuteNonQuery(SQLiteConnection connection, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {

            SQLiteCommand cmd = new SQLiteCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static SQLiteDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SQLiteDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;

            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExecuteScalar(SQLiteTransaction transaction, CommandType commandType, string commandText, params SQLiteParameter[] commandParameters)
        {
            if (transaction == null)
                throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null)
                throw new ArgumentException("The transaction was rollbacked	or commited, please	provide	an open	transaction.", "transaction");

            SQLiteCommand cmd = new SQLiteCommand();
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
            object retval = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return retval;
        }

        public static object ExecuteScalar(SQLiteConnection conn, CommandType commandType, string commandText, params SQLiteParameter[] commandParameters)
        {
            SQLiteCommand cmd = new SQLiteCommand();

            PrepareCommand(cmd, conn, null, commandType, commandText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        private static void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, CommandType cmdType, string cmdText, SQLiteParameter[] commandParameters)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            if (trans != null)
                cmd.Transaction = trans;

            if (commandParameters != null)
            {
                foreach (SQLiteParameter parm in commandParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
    }
}
