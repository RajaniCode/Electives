using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class GridView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridView1.DataSource = BuildDataTable();
            GridView1.DataBind();
        }
    }

    public DataTable BuildDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("BookID", typeof(string));
        dt.Columns.Add("Title", typeof(string));
        dt.Columns.Add("Author", typeof(string));
        dt.Columns.Add("Genre", typeof(string));
        dt.Columns.Add("RefNumber", typeof(string));
        dt.Rows.Add("34567", "Alchemist", "Paulo Coelho", "Fiction", "LNC1238.11");
        dt.Rows.Add("34568", "Jonathan Livingston Seagull", "Richard Bach", "Fiction", "KL4532.67");
        dt.Rows.Add("34569", "Heart of Darkness", "Joseph Conrad", "Classic", "CA5643.23");
        dt.Rows.Add("34570", "Oliver Twist", "Charles Dickens", "Classic", "CA8933.55");
        return dt;
    }
}