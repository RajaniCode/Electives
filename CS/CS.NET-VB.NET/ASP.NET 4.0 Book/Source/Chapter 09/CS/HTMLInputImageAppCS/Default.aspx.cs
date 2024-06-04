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

    protected void Image1_ServerClick(object sender, ImageClickEventArgs e)
    {
        span1.InnerHtml = "You have clicked submit button.";
    }
    protected void Image2_ServerClick(object sender, ImageClickEventArgs e)
    {
        span1.InnerHtml = "You have clicked reset button.";
    }

}
