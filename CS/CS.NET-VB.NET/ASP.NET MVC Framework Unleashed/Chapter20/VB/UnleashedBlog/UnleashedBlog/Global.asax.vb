' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute( _
            "ArchiveFull", _
            "archive/{year}/{month}/{day}/{name}", _
            New With {Key .controller = "Archive", Key .action = "Index"})


        routes.MapRoute( _
            "ArchiveYearMonthDay", _
            "archive/{year}/{month}/{day}", _
            New With {Key .controller = "Archive", Key .action = "Index"})


        routes.MapRoute( _
            "ArchiveYearMonth", _
            "archive/{year}/{month}", _
            New With {Key .controller = "Archive", Key .action = "Index"})


        routes.MapRoute( _
            "ArchiveYear", _
            "archive/{year}", _
            New With {Key .controller = "Archive", Key .action = "Index"})


        routes.MapRoute("Default", "{controller}/{action}/{id}", New With {Key .controller = "Blog", Key .action = "Index", Key .id = ""})

    End Sub

    Sub Application_Start()
        RegisterRoutes(RouteTable.Routes)
    End Sub
End Class
