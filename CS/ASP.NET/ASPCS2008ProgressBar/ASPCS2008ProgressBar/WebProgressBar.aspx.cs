using System;
using System.Collections;
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

using System.Web.SessionState;
using System.Text;
using System.Threading;

public partial class WebProgressBar : System.Web.UI.Page
{
    private void LongTask()
    {

        for (int i = 0; i < 11; i++)
        {
            System.Threading.Thread.Sleep(250);
            Session["State"] = i + 1;
        }
        Session["State"] = 100;

    }
    public static void OpenProgressBar(System.Web.UI.Page Page)
    {
        StringBuilder sbScript = new StringBuilder();

        sbScript.Append("<script language='JavaScript' type='text/javascript'>\n");
        sbScript.Append("<!--\n");
        sbScript.Append("window.showModalDialog('Progress.aspx','','dialogHeight: 150px; dialogWidth: 350px; edge: Raised; center: Yes; help: No; resizable: No; status: No;scroll:No;');\n");
        sbScript.Append("// -->\n");
        sbScript.Append("</script>\n");
        Page.RegisterClientScriptBlock("OpenProgressBar", sbScript.ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Thread thread = new Thread(new ThreadStart(LongTask));
        thread.Start();

        Session["State"] = 1;
        OpenProgressBar(this.Page);
    }

    
}

