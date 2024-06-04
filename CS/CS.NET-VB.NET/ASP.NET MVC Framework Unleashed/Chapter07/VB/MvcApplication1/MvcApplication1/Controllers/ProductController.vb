Public Class ProductController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function


    ' GET: /Product/Create
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Product/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal productToCreate As Product) As ActionResult

        ' Add product to database
        Return RedirectToAction("Index")
    End Function

End Class
