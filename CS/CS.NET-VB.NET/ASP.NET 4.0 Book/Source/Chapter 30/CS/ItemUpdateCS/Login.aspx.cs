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
        this.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MembershipUser memUser = Membership.GetUser(textbox1.Text);
        if (memUser != null && memUser.IsLockedOut == true)
            memUser.UnlockUser();
        label1.Visible = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
		string userName = textbox1.Text;
		string password = textbox2.Text;
		if (Membership.ValidateUser(userName, password))
		{
			if (Request.QueryString["ReturnUrl"] != null)
			{
				FormsAuthentication.RedirectFromLoginPage(userName, false);
			}
			else
			{
				FormsAuthentication.SetAuthCookie(userName, false);
				Response.Redirect("default.aspx");
			}
		}
		else
		{
			label1.Visible = true;
			label1.Text = "Unsuccessful login.  Please re-enter your information and try again.";
		}
		if ((Membership.GetUser(userName) != null) && 
 		  (Membership.GetUser(userName).IsLockedOut == true))
		{
			label1.Text = "  <b>Your account has been locked out.</b>";

    }
}
}
