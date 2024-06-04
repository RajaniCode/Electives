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

public partial class RegisterUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        TextBox UserNameTextBox = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("UserName");
        SqlDataSource DataSource = (SqlDataSource)CreateUserWizardStep1.ContentTemplateContainer.FindControl("InsertExtraInfo");

        MembershipUser User = Membership.GetUser(UserNameTextBox.Text);
        object UserGUID = User.ProviderUserKey;

        DataSource.InsertParameters.Add("UserId", UserGUID.ToString());
        DataSource.Insert();

    }
}
