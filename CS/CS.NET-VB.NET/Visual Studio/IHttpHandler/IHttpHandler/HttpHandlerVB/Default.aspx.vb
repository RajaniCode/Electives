Imports System.Web.Security


Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lnkLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

End Class

