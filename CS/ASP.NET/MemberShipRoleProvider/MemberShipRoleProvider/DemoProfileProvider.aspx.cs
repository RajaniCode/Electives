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
using System.Web.Profile;

public partial class DemoProfileProvider : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnfinish_Click(object sender, EventArgs e)
    {
        MembershipCreateStatus p = MembershipCreateStatus.Success;
        Membership.CreateUser(txtusername.Text, txtpassword.Text, txtemailid.Text, txtsecurityquestion.Text, txtsecurityanswer.Text, true,out p);
        SaveProfile();
        Response.Redirect("Login.aspx");
    }

    public void SaveProfile()
    {
        Profile.Name = txtfullname.Text;
        Profile.DateofBirth = Convert.ToDateTime(txtdateofbirth.Text);
        Profile.AboutMe = txtaboutme.Text;
        Profile.Designation = txtdesignation.Text;
        Profile.Employer = txtemployer.Text;
        Profile.Languages = txtlanguages.Text;
        Profile.BirthPlace = txtplace.Text;
        Profile.Place = txtlivesin.Text;
        Profile.Project = txtproject.Text;
        Profile.University = txtusername.Text;
        Profile.Save();
    }
}
