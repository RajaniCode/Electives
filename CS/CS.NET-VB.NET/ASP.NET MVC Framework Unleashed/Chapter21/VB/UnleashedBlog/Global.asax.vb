' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394801

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute("Details", "archive/{year}/{month}/{day}/{name}", _
                        New With {Key .controller = "Archive", Key .action = "Details"})


        routes.MapRoute("ArchiveYearMonthDay", "archive/{year}/{month}/{day}", New With {Key .controller = "Archive", Key .action = "Index"})


        routes.MapRoute("ArchiveYearMonth", "archive/{year}/{month}", New With {Key .controller = "Archive", Key .action = "Index"})


        routes.MapRoute("ArchiveYear", "archive/{year}", New With {Key .controller = "Archive", Key .action = "Index"})


        routes.MapRoute("Default", "{controller}/{action}/{id}", New With {Key .controller = "Blog", Key .action = "Index", Key .id = ""})

    End Sub

    Protected Sub Application_Start()
        RegisterRoutes(RouteTable.Routes)
    End Sub

End Class
