using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data.OleDb;
using System.Collections.Generic;

namespace ASPCS2008Excel
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TimeLog.WriteTimeLog("DataAdapter");
            //DataTable Dt = GetDataTable();

            TimeLog.WriteTimeLog("DataReader");
            DataTable Dt = ReadDataTable();

            GridView1.DataSource = Dt.DefaultView;
            GridView1.DataBind();

            TimeLog.WriteTimeLog("Databound");
        }

        private DataTable GetDataTable()
        {
            DataTable Dt = new DataTable();
            DataTable Dat = new DataTable();
            try
            {
                //string connString = ConfigurationManager.ConnectionStrings["xls"].ConnectionString;  
                //string connString = ConfigurationManager.ConnectionStrings["xlsx"].ConnectionString;
                //string connString = ConfigurationManager.ConnectionStrings["xlsDuplicate"].ConnectionString;  
                string connString = ConfigurationManager.ConnectionStrings["xlsxDuplicate"].ConnectionString;

                //string FilePath = Server.MapPath("~/Excel.xls");
                //string FilePath = Request.MapPath("~/Excel.xls");
                //string FilePath = @"F:\Snippet\ASPCS2008Excel\ASPCS2008Excel\Excel.xls";
                //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + FilePath + "';Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";

                //string FilePath = Server.MapPath("~/Excelx.xlsx");
                //string FilePath = Request.MapPath("~/Excelx.xlsx");
                //string FilePath = @"F:\Snippet\ASPCS2008Excel\ASPCS2008Excel\Excelx.xlsx";
                //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + FilePath + "';Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    //Get All Sheets Name
                    DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });

                    //Get the First Sheet Name
                    string firstSheetName = sheetsName.Rows[0][2].ToString();

                    //Query String 
                    string sql = string.Format("SELECT * FROM [{0}]", firstSheetName);

                    OleDbDataAdapter ada = new OleDbDataAdapter(sql, connString);
                    DataSet ds = new DataSet();
                    ada.Fill(ds);

                    Dat = ds.Tables[0];
                    var count = Dat.Rows.Count;                

                    //Dt = GetDataTableUniqueRows(Dat);

                    Dt = Dat.DefaultView.ToTable(true);
                    var counter = Dt.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
            }
            return Dt;
        }

        private DataTable ReadDataTable()
        {
            DataTable Dt = new DataTable();
            DataTable Dat = new DataTable();
            try
            {
                //string connString = ConfigurationManager.ConnectionStrings["xls"].ConnectionString;  
                //string connString = ConfigurationManager.ConnectionStrings["xlsx"].ConnectionString;
                //string connString = ConfigurationManager.ConnectionStrings["xlsDuplicate"].ConnectionString;  
                string connString = ConfigurationManager.ConnectionStrings["xlsxDuplicate"].ConnectionString;  

                //string FilePath = Server.MapPath("~/Excel.xls");
                //string FilePath = Request.MapPath("~/Excel.xls");
                //string FilePath = @"F:\Snippet\ASPCS2008Excel\ASPCS2008Excel\Excel.xls";
                //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + FilePath + "';Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";

                //string FilePath = Server.MapPath("~/Excelx.xlsx");
                //string FilePath = Request.MapPath("~/Excelx.xlsx");
                //string FilePath = @"F:\Snippet\ASPCS2008Excel\ASPCS2008Excel\Excelx.xlsx";
                //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + FilePath + "';Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();

                    DataTable Schema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (Schema == null || Schema.Rows.Count < 1)
                    {
                        throw new Exception("Error: Could not determine the name of the first worksheet.");
                    }

                    DataTable SheetNames = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });

                    string FirstSheetName = SheetNames.Rows[0][2].ToString();

                    string SQL = string.Format("SELECT * FROM [{0}]", FirstSheetName);


                    OleDbCommand dbCommand = new OleDbCommand(SQL, conn);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();

                    //DataTable schemaTable = dbReader.GetSchemaTable();  
              
                    Dat.Load(dbReader);
                    var count = Dat.Rows.Count; 
                   
                    //Dt = GetDataTableUniqueRows(Dat);

                    Dt = Dat.DefaultView.ToTable(true); 
                    var counter = Dt.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
            }
            return Dt;
        }

        private DataTable GetDataTableUniqueRows(DataTable Dt)
        {
            DataTable Dat = new DataTable();
            try
            {
                List<DataRow> DataRowList = new List<DataRow>();

                // Get rows from the table. 
                IEnumerable<DataRow> Query = (from rows in Dt.AsEnumerable()
                                              select rows);

                DataTable Table = Query.CopyToDataTable();

                // Add rows to the list. 
                foreach (DataRow row in Table.Rows)
                {
                    DataRowList.Add(row);
                }

                // Create duplicate rows by adding the same rows to the list. 
                foreach (DataRow row in Table.Rows)
                {
                    DataRowList.Add(row);
                }

                DataTable table = DataTableExtensions.CopyToDataTable<DataRow>(DataRowList);

                // Find the unique column in the table. 
                IEnumerable<DataRow> UniqueDataRows = table.AsEnumerable().Distinct(DataRowComparer.Default);

                Dat = UniqueDataRows.CopyToDataTable();
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
            }
            return Dat;
        }
    }
}
