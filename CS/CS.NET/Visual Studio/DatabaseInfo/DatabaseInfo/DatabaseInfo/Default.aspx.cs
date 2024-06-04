using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;

namespace DatabaseInfo
{
    public partial class _Default : System.Web.UI.Page
    {
        private string Database
        {
            get
            {
                string database = "master";
                if (cboDatabase.Items.Count > 0)
                {
                    database = cboDatabase.SelectedValue;
                }
                return @"Data Source=MALCOLM-PC\SQLEXPRESS;Initial Catalog=" + database + ";Integrated Security=True";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Connect();        
            }
        }

        private void Connect()
        {
            using (SqlConnection cn = new SqlConnection(Database))
            {
                cn.Open();
                FetchDatabases(cn);
                FetchTableData(cn);
            }  
        }

        private void FetchTableData(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("sp_MSforeachtable @command1='EXEC sp_spaceused ''?''',@whereand='or OBJECTPROPERTY(o.id, N''IsSystemTable'') = 1'", cn);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                List<TableProperty> tables = new List<TableProperty>();
                while (dr.Read())
                {
                    tables.Add(new TableProperty()
                    {
                        Name = dr.GetString(0),
                        Rows = dr.GetString(1),
                        Reserved = dr.GetString(2),
                        Data = dr.GetString(3),
                        IndexSize = dr.GetString(4),
                        Unused = dr.GetString(5)
                    });
                    dr.NextResult();
                }

                grdTableInfo.DataSource = tables.OrderBy(o => o.Name);
                grdTableInfo.DataBind();
            }
        }

        private void FetchDatabases(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand("EXEC sp_MSforeachdb @command1='select ''?'''", cn);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                cboDatabase.Items.Clear();
                while (dr.Read())
                {
                    if (dr.GetString(0) != "tempdb")
                    {
                        cboDatabase.Items.Add(new ListItem(dr.GetString(0), dr.GetString(0)));
                    }
                    dr.NextResult();
                }
            }            
        }

        protected void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connect();
        }             
    }
}
