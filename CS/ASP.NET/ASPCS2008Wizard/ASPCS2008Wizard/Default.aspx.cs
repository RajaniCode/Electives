using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008Wizard
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Wizard1_ActiveStepChanged(object sender, EventArgs e)
        {
            if (Wizard1.ActiveStep.ID == "step3")
            {
                Label9.Text = ((TextBox)Wizard1.Controls[0].FindControl("TextBox1")).Text;
                Label10.Text = ((TextBox)Wizard1.Controls[0].FindControl("TextBox4")).Text;
                Label11.Text = ((TextBox)Wizard1.Controls[0].FindControl("TextBox5")).Text;
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            Label12.Text = "Thank you for registering with us";
            Wizard1.Visible = false;
        }
    }
}
