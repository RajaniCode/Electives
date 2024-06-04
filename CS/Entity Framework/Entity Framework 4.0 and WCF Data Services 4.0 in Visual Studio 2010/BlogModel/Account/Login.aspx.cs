using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace BlogModel.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void Login_Click(object sender, System.EventArgs e)
        {
            if (FormsAuthentication.Authenticate(LoginUser.UserName,
                       LoginUser.Password))
                FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName,
                       LoginUser.RememberMeSet);
        }

    }
}
