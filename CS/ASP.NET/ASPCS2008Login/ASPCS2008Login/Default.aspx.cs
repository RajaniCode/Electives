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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Hack: Create three dummy roles if no roles are currently in the role system
            // I am using this to avoid having to write a setup script.
            string[] roles = Roles.GetAllRoles();

            if (roles.Length == 0)
            {
                Roles.CreateRole("Friends");
                Roles.CreateRole("Enemies");
                Roles.CreateRole("Countrymen");
            }
        }
    }
}
