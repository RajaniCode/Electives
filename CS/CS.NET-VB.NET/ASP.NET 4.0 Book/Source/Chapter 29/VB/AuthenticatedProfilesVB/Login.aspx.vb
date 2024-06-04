
Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Page.User.Identity.IsAuthenticated Then
            Response.Redirect("Displayprofile.aspx")
        End If
    End Sub

    Protected Sub BtnCreateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("CreateUser.aspx")
    End Sub
End Class
