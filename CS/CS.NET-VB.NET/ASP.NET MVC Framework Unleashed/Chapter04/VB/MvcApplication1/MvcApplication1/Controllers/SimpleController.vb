Public Class SimpleController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewData("message") = "Hello World!"
        Return View()
    End Function

End Class
