using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
public partial class AddEvent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         time.Text = DateTime.Now.ToString();
        WindowsPrincipal WP = (WindowsPrincipal)HttpContext.Current.User;
        WindowsIdentity WI = (WindowsIdentity)WP.Identity;
        string winUser = "Name: " + WI.Name;
        winUser += "\nAuthentication Type: " + WI.AuthenticationType;
        winUser += "\nAuthenticated: " + ((WI.IsAuthenticated) ? "Yes" : "No");
        user.Text = winUser;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    
        SqlDataSource1.Insert();
        ID.Text = "";
        name.Text = "";
        location.Text = "";
        Label8.Text = "1 new event created";
    }
}