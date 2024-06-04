Public Class Movie2Controller
    Inherits System.Web.Mvc.Controller

    ' GET: /Movie2/Create
    Function Create() As ActionResult
        Return View()
    End Function

    ' POST: /Movie2/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    Function Create(ByVal collection As FormCollection) As ActionResult
        Dim movieToCreate As New Movie()
        Me.UpdateModel(movieToCreate, collection.ToValueProvider())
        ' Insert movie into database
        Return RedirectToAction("Index")
    End Function


End Class
