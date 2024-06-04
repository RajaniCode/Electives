using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Profile;

public partial class Manageprofile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_PreRender()
    {
        Txtnumprofiles.Text =
        ProfileManager.GetNumberOfProfiles(ProfileAuthenticationOption.All).ToString();
    }

    protected void Btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            int del = 0;
            del =
            ProfileManager.DeleteInactiveProfiles(ProfileAuthenticationOption.All,
            DateTime.Now.AddMinutes(-4));
            Label1.Text = String.Format("{0} Profiles deleted ", del);
        }

        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}