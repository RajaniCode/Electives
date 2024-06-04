using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void login_Click(object sender, EventArgs e)
    {

        if (FormsAuthentication.Authenticate(textBox1.Text, textBox2.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(textBox1.Text, checkBox1.Checked);
        }
        else
        {
            label1.Text = "<b>Invalid Credentials! Please enter credentials again.";
        }

    }
}