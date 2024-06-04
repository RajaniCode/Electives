Public Class Movie3Controller
    Inherits System.Web.Mvc.Controller

    ' GET: /Movie3/Create
    <ActionName("Create")> _
    Function Create_GET() As ActionResult
        Return View()
    End Function

    ' POST: /Movie3/Create
    <AcceptVerbs(HttpVerbs.Post)> _
    <ActionName("Create")> _
    Function Create_POST() As ActionResult
        Dim movieToCreate As New Movie()
        Me.UpdateModel(movieToCreate, New String() {"Title", "Director", "DateReleased"})
        ' Insert movie into database
        Return RedirectToAction("Index")
    End Function


End Class
