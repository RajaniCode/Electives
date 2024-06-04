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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        WebPartManager wpm = new WebPartManager();
        CatalogZone cz = new CatalogZone();
        String str;
        cz.EmptyZoneText = "no controls found!!!";
        Label4.Text = cz.EmptyZoneText;
        cz.SelectedCatalogPartID = "selected zone..";
        Label6.Text = cz.SelectedCatalogPartID;
        str = WebPartManager.CatalogDisplayMode.Name;
        Label8.Text = str;
        Label4.Visible = true;
        Label6.Visible = true;
        Label8.Visible = true;

    }
}