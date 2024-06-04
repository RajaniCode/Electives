Imports Microsoft.VisualBasic
Namespace CustomHTTP
    Public Class CustomHandler
        Implements IHttpHandler
        Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
            Get
                Return True
            End Get
        End Property
        Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
            Dim Response As HttpResponse = context.Response
            Response.Write("<html><body><H2>Sample HTTP Handler</H2></body></html>")
        End Sub
    End Class
End Namespace

