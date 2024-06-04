using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace Globalization
{

    public partial class _Default : System.Web.UI.Page
    {
        
        protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            setCulture();
        }


        private void setCulture()
        {
            string strCulture = ddlLanguages.SelectedItem.Value;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(strCulture);
            UpdateUI();
        }
        private void UpdateUI()
        {
            
            lblUserId.Text = HttpContext.GetGlobalResourceObject("Resource", "lblUserIdResource1").ToString();
            lblPassword.Text = HttpContext.GetGlobalResourceObject("Resource", "lblPasswordResource1").ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setCulture();
            }
        }
    }
}