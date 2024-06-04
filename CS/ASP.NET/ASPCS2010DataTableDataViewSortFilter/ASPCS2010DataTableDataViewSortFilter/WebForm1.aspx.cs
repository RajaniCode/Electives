using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
// Add Reference
using System.Configuration;

namespace ASPCS2010DataTableDataViewSortFilter
{
    public partial class WebForm1 : System.Web.UI.Page
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
                    var Error = ex.Message;
                    return string.Empty;
                }
            }
        }

        private DataSet GetDataSet()
        {
            DataSet DatSet = new DataSet();

            try
            {
                string SqlQuery = "SELECT * FROM dbo.Employees; ";

                using (SqlConnection ConnectionSql = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter DataAdapterSql = new SqlDataAdapter(SqlQuery, ConnectionSql);
                    SqlCommandBuilder CommandBuilderSql = new SqlCommandBuilder(DataAdapterSql);
                    DataAdapterSql.Fill(DatSet, "Employees");
                }
            }
            catch (Exception ex)
            {
                var Error = ex.Message;
            }

            return DatSet;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet DatSet = GetDataSet();
            GridView1.DataSource = DatSet.Tables["Employees"].DefaultView;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet DatSet = GetDataSet();

            string filterExpression = "Country  = 'USA'";
            string sort = "City DESC";

            DataRow[] DatRows = DatSet.Tables["Employees"].Select(filterExpression, sort, DataViewRowState.CurrentRows);

            DataTable DatTable = DatRows.CopyToDataTable();
            GridView1.DataSource = DatTable.DefaultView;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet DatSet = GetDataSet();
            GridView1.DataSource = DatSet.Tables["Employees"].DefaultView;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataSet DatSet = GetDataSet();

            string RowFilter = "TitleOfCourtesy = 'Ms.'";
            string Sort = "City";

            DataView DatView = new DataView(DatSet.Tables["Employees"], RowFilter, Sort, DataViewRowState.CurrentRows);

            GridView1.DataSource = DatView;
            GridView1.DataBind();
        }
    }
}