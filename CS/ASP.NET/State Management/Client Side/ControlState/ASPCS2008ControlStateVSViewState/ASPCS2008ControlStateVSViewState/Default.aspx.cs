using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008ControlStateVSViewState
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = (IndexButton1.Index++).ToString();
            Label2.Text = (IndexButton1.IndexInViewState++).ToString();
            
            if (!IsPostBack)
            {

            }

            if(!IsCallback)
            {

            }
        }
    }
}
