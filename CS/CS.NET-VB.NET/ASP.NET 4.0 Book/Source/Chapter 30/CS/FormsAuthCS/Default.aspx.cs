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
        label1.Text = "Welcome, " + HttpContext.Current.User.Identity.Name;
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}