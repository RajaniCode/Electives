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

namespace ASPCS2008LINQDuplicateRows
{
    public partial class _Default : System.Web.UI.Page
    {
        private string ConnectionString
        {
            get
            {
                try
                {
                    ConnectionStringSettingsCollection ConnectionStringSetting = ConfigurationManager.ConnectionStrings;
                    return ConnectionStringSetting["ConnectionString"].ConnectionString;
                }
                catch (Exception ex)
                {
                    string Error = ex.ToString();
                    return string.Empty;
                }
            }
        }

        private DataTable GetDataTable()
        {
            DataTable DtTable = new DataTable();
   
            try
            {
                string Query = "SELECT * FROM dbo.DuplicateRcordTable; ";               

                using (OleDbConnection ConnectionSql = new OleDbConnection(ConnectionString))
                {
                    OleDbDataAdapter DataAdapterSql = new OleDbDataAdapter();
                    DataAdapterSql.SelectCommand = new OleDbCommand(Query, ConnectionSql);
                    DataAdapterSql.Fill(DtTable);
                }
            }
            catch (Exception ex)
            {
                string Error = ex.ToString();
            }

            return DtTable;
        }        

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable Dt = GetDataTable();

            GridView1.DataSource = Dt.DefaultView;
            GridView1.DataBind();
        }

        private DataTable GetDataTableUniqueRows(DataTable dt)
        {
            DataTable Dt = new DataTable();
            try
            {
                List<DataRow> datarowList = new List<DataRow>();

                // Get rows from the table. 
                IEnumerable<DataRow> query = (from rows in dt.AsEnumerable()
                                              select rows);

                DataTable DtTemp = query.CopyToDataTable();

                // Add rows to the list. 
                foreach (DataRow row in DtTemp.Rows)
                {
                    datarowList.Add(row);
                }

                // Create duplicate rows by adding the same rows to the list. 
                foreach (DataRow row in DtTemp.Rows)
                {
                    datarowList.Add(row);
                }

                DataTable table = DataTableExtensions.CopyToDataTable<DataRow>(datarowList);

                // Find the unique column in the table. 
                IEnumerable<DataRow> uniqueDataRows = table.AsEnumerable().Distinct(DataRowComparer.Default);

                Dt = uniqueDataRows.CopyToDataTable();
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
            }
            return Dt;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataView Dv = GridView1.DataSource as DataView;
            //DataTable DtUniqueRows = GetDataTableUniqueRows(Dv.Table);

            DataTable Dt = GetDataTable();
            DataTable DtUniqueRows = Dt.DefaultView.ToTable(true);

            GridView1.DataSource = DtUniqueRows.DefaultView;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable Dt = GetDataTable();

            GridView1.DataSource = Dt.DefaultView;
            GridView1.DataBind();
        }   

    }
}
