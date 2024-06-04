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
        WebService ts = new WebService();
        Label1.Text = ts.GetServerTime().ToString();
        Label2.Text = ts.GetServerTime().ToString();

    }
}