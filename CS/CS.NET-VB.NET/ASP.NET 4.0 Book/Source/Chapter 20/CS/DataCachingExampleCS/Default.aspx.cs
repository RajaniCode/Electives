using System;
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

public partial class _Default : System.Web.UI.Page
{
    DataSet DataSet1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Cache["MyCacheDataset"] == null)
        {
            DataSet1.ReadXml(Server.MapPath("Authors.xml"));
            Cache.Insert("MyCacheDataset", DataSet1, new
              System.Web.Caching.CacheDependency(Server.MapPath("Authors.xml")));
            Label2.Text = "Cache Generated";
        }
        else
        {
            Label2.Text = "Using pre-generated Cache";
        }
        DataGrid1.DataSource = Cache["MyCacheDataset"];
        DataGrid1.DataBind();

    }
}