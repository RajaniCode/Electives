using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        MembershipUser updatesuser = Membership.GetUser();
        updatesuser.Email = (string)e.NewValues[0];
        updatesuser.Comment = (string)e.NewValues[1];
        Membership.UpdateUser(updatesuser);
        e.Cancel = true;
        DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("login.aspx");

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Membership.DeleteUser(User.Identity.Name);
        FormsAuthentication.SignOut();
        Response.Redirect("login.aspx");

    }
}