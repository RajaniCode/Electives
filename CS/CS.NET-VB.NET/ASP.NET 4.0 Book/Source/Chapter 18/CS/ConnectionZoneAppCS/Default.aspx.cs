using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page
{
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager.ConnectDisplayMode;
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode;
    }

}