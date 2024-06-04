using System;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// This article has been written for DotNetCurry.com
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBind_Click(object sender, EventArgs e)
    {
        string dataPath = MapPath(".") + "\\books.xml";

        DataSet ds = new DataSet();
        ds.ReadXml(dataPath);
        DataTable dt = ds.Tables[0];
        DataView dataView = new DataView(dt);
        // Bind XML
        chartBooks.Series[0].Points.DataBindXY(dataView, "title", dataView, "price");        
    }
}
