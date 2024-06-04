' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Public Overrides Function GetVaryByCustomString(ByVal context As HttpContext, ByVal custom As String) As String
        If custom = "JS" Then
            Return Request.Browser.EcmaScriptVersion.ToString()
        End If
        Return MyBase.GetVaryByCustomString(context, custom)
    End Function

    'Public Sub Application_BeginRequest()
    '    Debug.WriteLine("Application_BeginRequest")
    'End Sub

    'Public Sub Application_AuthenticateRequest()
    '    Debug.WriteLine("Application_AuthenticateRequest")
    'End Sub

    'Public Sub Application_AuthorizeRequest()
    '    Debug.WriteLine("Application_AuthorizeRequest")
    'End Sub

    'Public Sub Application_EndRequest()
    '    Debug.WriteLine("Application_EndRequest")
    'End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Home", .action = "Index", .id = ""} _
        )

    End Sub

    Sub Application_Start()
        RegisterRoutes(RouteTable.Routes)
    End Sub
End Class
