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
    PropertyGridEditorPart propgrid = new PropertyGridEditorPart();

    protected void Page_Load(object sender, EventArgs e)
    {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Visible = true;
        Label2.Visible = true;
        Label3.Visible = true;
        Label1.Text = propgrid.DisplayTitle;
        propgrid.Title = "MY PROPERTY GRID EDITOR PART!!!";
        Label2.Text = propgrid.Title;
        propgrid.ToolTip = "MY TOOLTIP";
        Label3.Text = propgrid.ToolTip;

    }
}