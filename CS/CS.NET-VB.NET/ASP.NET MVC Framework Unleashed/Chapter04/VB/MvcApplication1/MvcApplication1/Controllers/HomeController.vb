<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewData("message") = "Hello World!"
        Return View("Index")
    End Function

End Class
