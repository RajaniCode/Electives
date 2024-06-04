using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            Dropgetallroles.DataSource = Roles.GetAllRoles();
        Dropgetallroles.DataBind(); 
    }
    protected void BtnCreate_Click(object sender, EventArgs e)
    {
       
        try
		{
			Label1.Visible = true;
			Roles.CreateRole(TextBox1.Text);
			Dropgetallroles.DataSource = Roles.GetAllRoles();
			Dropgetallroles.DataBind(); 
			//Label1.Visible = false;
			Label1.Text="Role " + TextBox1.Text+" is Created" ; 
		}
		catch
		{
			Label1.Visible = true;
			Label1.Text = "Unable to create role, as this role exists. Please try another role name.";
		}

    }
    protected void BtnDelete_Click(object sender, EventArgs e)
    {

        Label1.Visible = true;
        Roles.DeleteRole(TextBox1.Text);
        Dropgetallroles.DataSource = Roles.GetAllRoles();
        Dropgetallroles.DataBind();
        Label1.Text = "Roles " + TextBox1.Text + " is deleted"; 

    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Label2.Visible = false;
            Roles.AddUserToRole(Txtusername.Text, TxtRolename.Text);
            GridView1.DataSource = Roles.GetUsersInRole(TxtRolename.Text);
            GridView1.DataBind();
        }
        catch
        {
            Label2.Visible = true;
            Label2.Text = "User Already exist";
        }

    }
    protected void BtnDelUser_Click(object sender, EventArgs e)
    {
        try
        {
            Roles.RemoveUserFromRole(Txtusername.Text, TxtRolename.Text);
            GridView1.DataSource = Roles.GetUsersInRole(TxtRolename.Text);
            GridView1.DataBind();
        }
        catch
        {
            Label2.Visible = true;
            Label2.Text = "User not exist";
        }

    }
}