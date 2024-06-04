Imports System.Web.Security
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub BtnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        Try
            Label1.Visible = True
            Roles.CreateRole(TextBox1.Text)
            Dropgetallroles.DataSource = Roles.GetAllRoles()
            Dropgetallroles.DataBind()
            Label1.Text = "Role " & TextBox1.Text & "is Created"
        Catch
            Label1.Visible = True
            Label1.Text = "Unable to create role, as this role exists. Please try another role name."
        End Try

    End Sub

    Protected Sub BtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Label1.Visible = True
        Roles.DeleteRole(TextBox1.Text)
        Dropgetallroles.DataSource = Roles.GetAllRoles()
        Dropgetallroles.DataBind()
        Label1.Text = "Roles " & TextBox1.Text & " is deleted"

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dropgetallroles.DataSource = Roles.GetAllRoles()
        Dropgetallroles.DataBind()

    End Sub

    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            Label2.Visible = False
            Roles.AddUserToRole(Txtusername.Text, TxtRolename.Text)
            GridView1.DataSource = Roles.GetUsersInRole(TxtRolename.Text)
            GridView1.DataBind()
        Catch
            Label2.Visible = True
            Label2.Text = "User Already exist"
        End Try

    End Sub

    Protected Sub BtnDelUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDelUser.Click
        Try
            Roles.RemoveUserFromRole(Txtusername.Text, TxtRolename.Text)
            GridView1.DataSource = Roles.GetUsersInRole(TxtRolename.Text)
            GridView1.DataBind()
        Catch
            Label2.Visible = True
            Label2.Text = "User not exist"
        End Try

    End Sub
End Class
