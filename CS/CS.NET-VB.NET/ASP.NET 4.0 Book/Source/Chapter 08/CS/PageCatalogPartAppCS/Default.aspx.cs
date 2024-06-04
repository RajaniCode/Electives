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
    WebPartManager wpm = new WebPartManager();
    PageCatalogPart pcp = new PageCatalogPart();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Text = Convert.ToString(pcp.ChromeState);
        Label3.Text = Convert.ToString(pcp.ChromeType);
        Label4.Text = pcp.Title;
        Label6.Text = Convert.ToString(pcp.EnableViewState);

    }
}