using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Displayprofile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Country.Text = Profile.Country;
        Gender.Text = Profile.Gender;
        Name.Text = Profile.Name;

    }
}