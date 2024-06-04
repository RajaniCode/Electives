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

namespace ASPCS2008Delay
{
    public partial class Welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome to New Page!";
            lblNote.Text = "Your data has been submitted successfully.";

            DataTable dt = ReadDataTable();
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }

        private DataTable ReadDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                //string connString = ConfigurationManager.ConnectionStrings["xls"].ConnectionString;  
                //string connString = ConfigurationManager.ConnectionStrings["xlsx"].ConnectionString;     

                //Connection String
                string strFileName = "D:\\Excel.xls";
                string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + strFileName + "';Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";

                //string strFileName = "D:\\ExcelX.xls";
                //string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + strFileName + "';Extended Properties='Excel 12.0;HDR=NO;IMEX=1';";

                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();

                    // Get the name of the first worksheet:
                    DataTable dbSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dbSchema == null || dbSchema.Rows.Count < 1)
                    {
                        throw new Exception("Error: Could not determine the name of the first worksheet.");
                    }

                    //Get All Sheets Name
                    DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });

                    //Get the First Sheet Name
                    string firstSheetName = sheetsName.Rows[0][2].ToString();

                    //Query String 
                    string sql = string.Format("SELECT * FROM [{0}]", firstSheetName);

                    // Now we have the table name; proceed as before:
                    OleDbCommand dbCommand = new OleDbCommand(sql, conn);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();

                    //DataTable schemaTable = dbReader.GetSchemaTable();                

                    DataTable dat = new DataTable();                 
                    dat.Load(dbReader);

                    //Unique Rows
                    dt = dat.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).CopyToDataTable(); 

                }
            }
            catch (Exception ex)
            {
                var v = ex.Message;
            }
            return dt;
        }
    }
}
