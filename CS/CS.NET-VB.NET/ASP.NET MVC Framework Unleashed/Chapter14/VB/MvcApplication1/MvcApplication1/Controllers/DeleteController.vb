Public Class DeleteController
    Inherits Controller

    Private _entities As New MoviesDBEntities()

    Public Function Index() As ActionResult
        Return View(_entities.MovieSet.ToList())
    End Function

    <AcceptVerbs(HttpVerbs.Delete)> _
    Public Function Delete(ByVal id As Integer) As ActionResult
        Dim movieToDelete = (From m In _entities.MovieSet _
                             Where m.Id = id _
                             Select m).FirstOrDefault()
        _entities.DeleteObject(movieToDelete)
        _entities.SaveChanges()
        Return PartialView("Movies", _entities.MovieSet.ToList())
    End Function

    <ActionName("Delete")> _
    Public Function Delete_GET(ByVal id As Integer) As ActionResult
        Dim movieToDelete = (From m In _entities.MovieSet _
                             Where m.Id = id _
                             Select m).FirstOrDefault()
        Return View(movieToDelete)
    End Function

    <AcceptVerbs(HttpVerbs.Post), ActionName("Delete")> _
    Public Function Delete_POST(ByVal id As Integer) As ActionResult
        Dim movieToDelete = (From m In _entities.MovieSet _
                             Where m.Id = id _
                             Select m).FirstOrDefault()
        _entities.DeleteObject(movieToDelete)
        _entities.SaveChanges()
        Return RedirectToAction("Index")
    End Function

End Class
