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
    protected void Button1_Click(object sender, EventArgs e)
    {
        MembershipCreateStatus status;
        Membership.CreateUser("Kogent", "abc@123", "k@kogent.com", "Favorite Color",
          "White", true, out status);
        if (Membership.ValidateUser(TextBox1.Text, TextBox2.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, false);
        }
        Label1.Text = " you are not a registered user!!!";

    }
}