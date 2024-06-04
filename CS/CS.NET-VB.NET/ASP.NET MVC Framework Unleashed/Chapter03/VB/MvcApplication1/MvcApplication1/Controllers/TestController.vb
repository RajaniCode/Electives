Public Class TestController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Test/

    Function Index() As ActionResult
        Return Content("Hello!")
    End Function

End Class
