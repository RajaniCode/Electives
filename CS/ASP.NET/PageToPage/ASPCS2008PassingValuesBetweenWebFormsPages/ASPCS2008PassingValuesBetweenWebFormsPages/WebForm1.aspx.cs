using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008PassingValuesBetweenWebFormsPages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _Default SourcePage = (_Default)Context.Handler;
                Label1.Text = SourcePage.Property1;
            }
        }
    }
}
