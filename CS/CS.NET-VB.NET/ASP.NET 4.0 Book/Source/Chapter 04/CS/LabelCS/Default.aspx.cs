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
        Label3.Text = "Welcome to the World of ASP.NET 4.0";
        Label4.Text = "I have Olive Color";
        Label4.BackColor = System.Drawing.Color.Olive;

    }
}