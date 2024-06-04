Imports System.Web
Imports System.Web.Services


Public Class CustomHandler
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If context.User.Identity.IsAuthenticated AndAlso context.User.Identity.Name.ToUpper() = "CEO" Then
            DownloadFile(context)
        Else
            context.Response.Write("No access unless you're the CEO!!!")
        End If
    End Sub

    Protected Sub DownloadFile(ByVal context As HttpContext)
        context.Response.Buffer = True
        context.Response.Clear()
        context.Response.AddHeader("content-disposition", context.Request.Url.AbsolutePath)
        context.Response.ContentType = "text/plain"
        context.Response.WriteFile(context.Server.MapPath(context.Request.Url.AbsolutePath))
    End Sub

    Public Overrides Function ToString() As String
        Return "Some generic description to define what this class does.."
    End Function


    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class

