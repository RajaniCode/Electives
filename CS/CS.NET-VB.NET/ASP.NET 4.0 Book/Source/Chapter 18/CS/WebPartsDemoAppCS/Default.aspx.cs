using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode;
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager.EditDisplayMode;
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager.CatalogDisplayMode;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager.DesignDisplayMode;
    }
}