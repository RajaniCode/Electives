
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim status As MembershipCreateStatus
        Membership.CreateUser("Kogent", "abc@123", "k@kogent.com", "Favorite Color", "White", True, status)
        If Membership.ValidateUser(TextBox1.Text, TextBox2.Text) Then
            FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, False)
        End If
        Label1.Text = " you are not a registered user!!!"

    End Sub
End Class
