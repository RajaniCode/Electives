using System;
using System.Web.Security;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}
