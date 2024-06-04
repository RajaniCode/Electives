Public Class CustomerController
    Inherits System.Web.Mvc.Controller

    ' GET: /Customer/Create
    Function Create() As ActionResult
        Return View()
    End Function


    ' POST: /Customer/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal customerToCreate As Customer) As ActionResult
        ' Add customer to database
        Return RedirectToAction("Index")
    End Function

End Class
