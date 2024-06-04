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

using System.Text;

namespace ASPCS2008Membership.User
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserInfo();
            }
        }

        public void UserInfo()
        {
            StringBuilder text = new StringBuilder();
            string s = Profile.Name + Profile.Designation + "at" + Profile.Employer + "Lives in" + Profile.Place + "From" + Profile.BirthPlace;
            text.Append(s);
            Literal1.Text = text.ToString();
        }
    }
}
