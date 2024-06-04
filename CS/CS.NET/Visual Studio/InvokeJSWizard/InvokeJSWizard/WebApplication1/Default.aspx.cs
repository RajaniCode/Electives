using System;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btn = Wizard1.FindControl("StartNavigationTemplateContainerID").FindControl("StartNextButton") as Button;
            if (btn != null)
            {
                btn.OnClientClick = "return confirm('Are you sure you want to move away from the beginning?')";                
            }

            btn = Wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("StepNextButton") as Button;
            if (btn != null)
            {
                btn.OnClientClick = "return confirm('Are you positive you want to move next?')";
            }

            btn = Wizard1.FindControl("StepNavigationTemplateContainerID").FindControl("StepPreviousButton") as Button;
            if (btn != null)
            {
                btn.OnClientClick = "return confirm('Are you sure you want to go back?')";
            }

            btn = Wizard1.FindControl("FinishNavigationTemplateContainerID").FindControl("FinishPreviousButton") as Button;
            if (btn != null)
            {
                btn.OnClientClick = "return confirm('Almost there!?')";
            }
        }       
    }
}
