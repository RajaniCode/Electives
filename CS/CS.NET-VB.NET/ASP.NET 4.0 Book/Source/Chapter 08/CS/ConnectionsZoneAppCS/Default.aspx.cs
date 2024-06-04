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
    ConnectionsZone conn = new ConnectionsZone();

    protected void Page_Load(object sender, EventArgs e)
    {
        string value;
        value = conn.NoExistingConnectionInstructionText;
        conn.NoExistingConnectionInstructionText = value;
        Label3.Text = conn.NoExistingConnectionInstructionText;
        Label4.Text = "DEFAULT:" + conn.ConfigureConnectionTitle;
        conn.ConfigureConnectionTitle = "Configure a new connection";
        Label6.Text = "CUSTOM:" + conn.ConfigureConnectionTitle;

    }
}