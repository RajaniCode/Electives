using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void createbutton_Click(object sender, EventArgs e)
    {
        MembershipCreateStatus status;
        Membership.CreateUser(myUserId.Text, myPassword.Text, myEmail.Text,
          dropdownlist1.SelectedValue, myPasswordAnswer.Text, true, out status);
        switch (status)
        {
            case (MembershipCreateStatus.Success):
                myUserId.Text = null;
                myPassword.Text = null;
                myEmail.Text = null;
                dropdownlist1.SelectedIndex = -1;
                myPasswordAnswer.Text = null;

                lblresults.Text = "User successfully created!";
                break;
            case (MembershipCreateStatus.DuplicateUserName):
                lblresults.Text = "User already exist";
                break;
            default:
                lblresults.Text = "error creating users";
                break;
        }
        lblresults.Visible = true;
    }

    
}