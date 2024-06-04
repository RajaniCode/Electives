
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        If FormsAuthentication.Authenticate(textBox1.Text, textBox2.Text) Then
            FormsAuthentication.RedirectFromLoginPage(textBox1.Text, checkBox1.Checked)
        Else
            label1.Text = "<b>Invalid Credentials! Please enter credentials again."
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
