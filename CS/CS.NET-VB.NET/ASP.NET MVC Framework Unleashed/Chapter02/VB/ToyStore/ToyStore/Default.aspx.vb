Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HttpContext.Current.RewritePath(Request.ApplicationPath, False)
        Dim httpHandler As IHttpHandler = New MvcHttpHandler()
        httpHandler.ProcessRequest(HttpContext.Current)
    End Sub

End Class
