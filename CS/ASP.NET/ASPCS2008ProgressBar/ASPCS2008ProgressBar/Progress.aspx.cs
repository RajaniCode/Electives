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

public partial class Progress : System.Web.UI.Page
{
    private int state = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["State"] != null)
        {
            state = Convert.ToInt32(Session["State"].ToString());
        }
        else
        {
            Session["State"] = 0;
        }
        if (state > 0 && state <= 10)
        {
            this.lblMessages.Text = "Processing...";
            this.panelProgress.Width = state * 30;
            this.lblPercent.Text = state * 10 + "%";
            Page.RegisterStartupScript("", "<script>window.setTimeout('window.Form1.submit()',100);</script>");
        }
        if (state == 100)
        {
            this.panelProgress.Visible = false;
            this.panelBarSide.Visible = false;
            this.lblMessages.Text = "Task Completed!";
            Page.RegisterStartupScript("", "<script>window.close();</script>");
        }
    }
}

