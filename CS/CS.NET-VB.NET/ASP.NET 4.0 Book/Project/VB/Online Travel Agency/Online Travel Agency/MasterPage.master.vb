Public Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (LoginName1.Page.User.Identity.IsAuthenticated) Then
            hlChangePassowrd.Visible = True
            LoginStatus1.Visible = True
            Login1.Visible = False
        Else
            hlChangePassowrd.Visible = False
            LoginStatus1.Visible = False
            Login1.Visible = True
        End If
    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
End Class