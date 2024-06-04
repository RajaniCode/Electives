using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Profile;

public partial class Createuser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        try
        {
            
            ProfileCommon pc = (ProfileCommon)ProfileCommon.Create(CreateUserWizard1.UserName, true);
            pc.Country =   ((DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Country")).SelectedValue;
            pc.Gender = ((DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Gender")).SelectedValue;
            pc.Name =   (((TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Name")).Text);
            //save profile
            pc.Save();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }
}