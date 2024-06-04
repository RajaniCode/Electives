using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ASPCS2008Login
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Country.Text = Profile.Country;
            Gender.Text = Profile.Gender;
            Age.Text = Profile.Age.ToString();

            RoleList.DataSource = Roles.GetRolesForUser(User.Identity.Name);
            RoleList.DataBind();
        }
    }
}
