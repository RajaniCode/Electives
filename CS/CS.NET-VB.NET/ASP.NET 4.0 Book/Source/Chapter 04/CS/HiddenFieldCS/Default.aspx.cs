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
        HiddenField1.Value = "Welcome to the World of ASP.NET 4.0";
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Label2.Text = HiddenField1.Value;
    }

}