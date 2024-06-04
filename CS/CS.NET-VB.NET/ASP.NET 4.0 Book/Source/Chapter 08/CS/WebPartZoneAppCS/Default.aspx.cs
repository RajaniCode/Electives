using System;
using System.Data;
using System.Configuration;
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
        WebPartZone wpz = new WebPartZone();
        String str;
        wpz.MenuLabelText = TextBox1.Text;
        str = wpz.MenuLabelText;
        Label3.Text = "Header text:" + str;

    }
}