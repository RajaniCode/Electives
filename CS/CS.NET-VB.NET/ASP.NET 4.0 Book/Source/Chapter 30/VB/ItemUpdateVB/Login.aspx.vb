
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim memUser As MembershipUser = Membership.GetUser(textbox1.Text)
        If memUser IsNot Nothing AndAlso memUser.IsLockedOut = True Then
            memUser.UnlockUser()
        End If
        label1.Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim userName As String = textbox1.Text
        Dim password As String = textbox2.Text
        If Membership.ValidateUser(userName, password) Then
            If Request.QueryString("ReturnUrl") IsNot Nothing Then
                FormsAuthentication.RedirectFromLoginPage(userName, False)
            Else
                FormsAuthentication.SetAuthCookie(userName, False)
                Response.Redirect("default.aspx")
            End If
        Else
            label1.Visible = True
            label1.Text = "Unsuccessful login.  Please re-enter your information and try again."
        End If
        If (Membership.GetUser(userName) IsNot Nothing) AndAlso
           (Membership.GetUser(userName).IsLockedOut = True) Then
            label1.Text = "  <b>Your account has been locked out.</b>"
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.DataBind()
    End Sub
End Class
