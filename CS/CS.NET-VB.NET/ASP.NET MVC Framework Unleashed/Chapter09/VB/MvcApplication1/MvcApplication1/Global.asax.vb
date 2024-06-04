' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")



        routes.MapRoute( _
            "SortRoute", _
            "Sort/{*values}", _
            New With {.controller = "Sort", .action = "Index"} _
        )



        'routes.MapRoute( _
        '    "Product1", _
        '    "Product/{action}", _
        '    New With {.controller = "Product"} _
        ')



        'routes.MapRoute( _
        '    "DefaultNoAdmin", _
        '    "{controller}/{action}/{id}", _
        '    New With {.controller = "Home", .action = "Index", .id = ""}, _
        '    New With {.controller = New NotEqual("Admin")} _
        ')


        'routes.MapRoute( _
        '    "Admin", _
        '    "Admin/{action}", _
        '    New With {.controller = "Admin"}, _
        '    New With {.Auth = New AuthenticatedConstraint()} _
        ')


        routes.MapRoute( _
            "ProductInsert", _
            "Product/Insert", _
             New With {.controller = "Product", .action = "Insert"}, _
             New With {.method = New HttpMethodConstraint("POST")} _
        )



        'routes.MapRoute( _
        '  "BlogArchive", _
        '  "Archive/{entryDate}", _
        '  New With {.controller = "Blog", .action = "Archive"}, _
        '  New With {.entryDate = "\d{2}-\d{2}-\d{4}"} _
        ')


        'routes.MapRoute( _
        '    "BlogArchive", _
        '    "Archive/{entryDate}", _
        '    New With {.controller = "Blog", .action = "Archive"} _
        ')




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
