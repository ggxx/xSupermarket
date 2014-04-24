using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace xSupermarket.Framework.Repo
{
    public sealed class ExcelHelper
    {
        //private static readonly string EXCEL_2K10_CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Password=;User ID=Admin;Data Source={0};Mode=Share Deny Write;Extended Properties=\"HDR=YES;Jet OLEDB:Engine Type=37\"";
        private static readonly string EXCEL_2K7_CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=YES\"";
        private static readonly string EXCEL_2K3_CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\"";

        public static DataSet LoadExcelFile(string excelFile)
        {
            DataSet ds = new DataSet();
            using (OleDbConnection xlsConn = new OleDbConnection())
            {
                if (!File.Exists(excelFile))
                {
                    throw new Exception("Excel file does not exist!");
                }
                switch (new FileInfo(excelFile).Extension.ToUpper())
                {
                    case ".XLSX":
                        xlsConn.ConnectionString = string.Format(EXCEL_2K7_CONNECTION_STRING, excelFile);
                        break;
                    case ".XLS":
                        xlsConn.ConnectionString = string.Format(EXCEL_2K3_CONNECTION_STRING, excelFile);
                        break;
                    default:
                        throw new Exception("无法识别的文件格式");
                }
                try
                {
                    xlsConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("所选中的文件正处于编辑状态，请关闭该文件后再次尝试。");
                }
                try
                {
                    System.Data.DataTable dtSchema = xlsConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    for (int i = 0; i < dtSchema.Rows.Count; i++)
                    {
                        System.Data.DataTable dt = new System.Data.DataTable(dtSchema.Rows[i]["TABLE_NAME"].ToString().Replace("'", "").TrimEnd('$'));
                        OleDbDataAdapter da = new OleDbDataAdapter(string.Format("SELECT * FROM [{0}]", dtSchema.Rows[i]["TABLE_NAME"].ToString()), xlsConn);
                        da.Fill(dt);
                        ds.Tables.Add(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("读取文件失败");
                }
                finally
                {
                    try { xlsConn.Close(); }
                    catch { }
                }
            }
            return ds;
        }

        public static List<string> GetWorkSheetNameList(string excelFile)
        {
            List<string> list = new List<string>();
            using (OleDbConnection xlsConn = new OleDbConnection())
            {
                if (!File.Exists(excelFile))
                {
                    return list;
                }
                switch (new FileInfo(excelFile).Extension.ToUpper())
                {
                    case ".XLSX":
                        xlsConn.ConnectionString = string.Format(EXCEL_2K7_CONNECTION_STRING, excelFile);
                        break;
                    case ".XLS":
                        xlsConn.ConnectionString = string.Format(EXCEL_2K3_CONNECTION_STRING, excelFile);
                        break;
                    default:
                        throw new Exception("无法识别的文件格式");
                }
                try
                {
                    xlsConn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("所选中的文件正处于编辑状态，请关闭该文件后再次尝试");
                }
                try
                {
                    System.Data.DataTable dtSchema = xlsConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    for (int i = 0; i < dtSchema.Rows.Count; i++)
                    {
                        list.Add(dtSchema.Rows[i]["TABLE_NAME"].ToString().Replace("'", "").TrimEnd('$'));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("读取文件失败");
                }
                finally
                {
                    try { xlsConn.Close(); }
                    catch { }
                }
            }
            return list;
        }
    }
}
