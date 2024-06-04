using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
		{
			Name.Visible = false;
			Label1.Visible = false;
			Button1.Visible = false;
			Label2.Visible = true;
			Label2.Text = "The output of this page was cached for " + Name.Text + ". The Current time is " + DateTime.Now.ToString();
			}

    }
}