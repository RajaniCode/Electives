using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008GetPublicPropertyValuefromSourcePage
{
    public partial class _Default : System.Web.UI.Page
    {
        public String CurrentCity
        {
            get
            {
                return TextBox1.Text;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm1.aspx");
        }
    }
}
