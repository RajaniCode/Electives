Imports System.Web.Security


Partial Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As AuthenticateEventArgs)
        FormsAuthentication.Authenticate(Login1.UserName, Login1.Password)
        FormsAuthentication.RedirectFromLoginPage(Login1.UserName, True)
    End Sub

End Class

