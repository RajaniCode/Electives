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
    EditorZone ez = new EditorZone();

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = WebPartManager.EditDisplayMode.Name;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String str;
        String str1;
        str = ez.EmptyZoneText;
        Label2.Text = str;
        str1 = ez.HeaderText;
        Label3.Text = str1;

    }
}