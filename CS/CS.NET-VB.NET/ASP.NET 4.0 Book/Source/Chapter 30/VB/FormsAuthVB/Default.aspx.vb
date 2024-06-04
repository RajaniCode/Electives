
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        label1.Text = "Welcome, " & HttpContext.Current.User.Identity.Name
    End Sub
End Class
