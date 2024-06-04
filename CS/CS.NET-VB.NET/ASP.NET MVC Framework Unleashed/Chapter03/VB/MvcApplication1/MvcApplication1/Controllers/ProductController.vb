Public Class ProductController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Product/

    Function Index() As ActionResult
        Return View()
    End Function

    '
    ' GET: /Product/Help

    Function Help() As ActionResult
        Return View()
    End Function

    '
    ' GET: /Details/1

    Function Details(ByVal id As Integer) As ActionResult
        Return View()
    End Function


End Class
