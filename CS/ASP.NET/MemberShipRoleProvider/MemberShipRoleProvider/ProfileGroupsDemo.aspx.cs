using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class ProfileGroupsDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnfinish_Click(object sender, EventArgs e)
    {
        MembershipCreateStatus p = MembershipCreateStatus.Success;
        Membership.CreateUser(txtusername.Text, txtpassword.Text, txtemailid.Text, txtsecurityquestion.Text, txtsecurityanswer.Text, true, out p);
        SaveProfile();
        Response.Redirect("Login.aspx");
    }

    /// <summary>
    /// Save Profile using Groups.
    /// </summary>
   
    public void SaveProfile()
    {
        Profile.BasicInfo.Name = txtfullname.Text;
        Profile.BasicInfo.DateofBirth = Convert.ToDateTime(txtdateofbirth.Text);
        Profile.BasicInfo.AboutMe = txtaboutme.Text;
        Profile.ProfessionlProfile.Designation = txtdesignation.Text;
        Profile.ProfessionlProfile.Employer = txtemployer.Text;
        Profile.BasicInfo.Languages = txtlanguages.Text;
        Profile.BasicInfo.BirthPlace = txtplace.Text;
        Profile.BasicInfo.Place = txtlivesin.Text;
        Profile.ProfessionlProfile.Project = txtproject.Text;
        Profile.ProfessionlProfile.University = txtusername.Text;       
        Profile.Save();
       
    }

    /// <summary>
   /// Save Profiles using Custom Types.
   /// </summary>

    public void saveprofile()
    {
        Profile.UserInfo = new UserInfo(txtusername.Text, txtdateofbirth.Text, txtplace.Text, txtlivesin.Text, txtlanguages.Text, txtaboutme.Text, txtemployer.Text, txtproject.Text, txtdesignation.Text, txtcollege.Text);
        Profile.Save();
    }
}