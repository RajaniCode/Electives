
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        Page.Theme = Server.HtmlEncode(Request.QueryString("Theme"))
    End Sub
End Class
