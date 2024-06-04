using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginStatus1.Visible = false;
            if (Roles.IsUserInRole("Admin") || Roles.IsUserInRole("User"))
            {
                login.Visible = false;
                LoginStatus1.Visible = true;
            }
            if (this.Context.User.Identity.Name != null)
            {
                login.Visible = false; LoginStatus1.Visible = true;
            }
            if (Roles.IsUserInRole("Admin"))
            {
                Menu1.Items[1].Text = "Admin";
            }
            else
            {
                Menu1.Items[1].Text = "";
            }
        }    
    }
}
