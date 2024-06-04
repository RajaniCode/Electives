using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ParseTest : System.Web.UI.Page
{
    public string GGReq = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetGraphData();        
        
        PieGraph pg = new PieGraph();
        pg.GraphColors = "5566AA";
        pg.GraphHeight="125";
        pg.GraphWidth="250";
        pg.GraphTitle = "Welcome to Test Graph";
        pg.GraphTitleColor = "112233";
        pg.GraphTitleSize = "20";
        pg.dtData = dt;

        GGReq = pg.GenerateGraph();
        
        
        this.DataBind();
    }

    DataTable GetGraphData()
    {
        SqlConnection con = new SqlConnection(@"Server=\SQLEXPRESS;uid=sa;pwd=;database=TestDB");
        SqlCommand cmd = new SqlCommand("Select * from GraphSupp", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
