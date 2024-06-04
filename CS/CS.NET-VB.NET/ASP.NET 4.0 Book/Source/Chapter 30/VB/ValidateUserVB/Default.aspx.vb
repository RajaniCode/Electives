
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label1.Text = Convert.ToString(Membership.GetUser(User.Identity.Name))

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        FormsAuthentication.SignOut()
        Response.Redirect("login.aspx")
    End Sub
End Class
