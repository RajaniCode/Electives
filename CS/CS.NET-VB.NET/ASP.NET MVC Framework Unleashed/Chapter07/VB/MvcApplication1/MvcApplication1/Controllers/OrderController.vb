Public Class OrderController
    Inherits System.Web.Mvc.Controller

    ' GET: /Order/Create
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Order/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal shipping As Address, ByVal billing As Address) As ActionResult
        ' Insert into database
        Return RedirectToAction("Index")
    End Function

 End Class
