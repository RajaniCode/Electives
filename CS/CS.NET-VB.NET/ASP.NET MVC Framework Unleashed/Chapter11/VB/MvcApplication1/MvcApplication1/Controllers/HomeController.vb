<OutputCache(Duration:=30, VaryByParam:="None")> _
Public Class HomeController
    Inherits Controller

    Private _entities As New MoviesDBEntities()

    Public Function Index() As ActionResult
        Dim movies = _entities.MovieSet.ToList()
        Return View("Index", movies)
    End Function

    Public Function IndexCached() As ActionResult
        Dim movies = _entities.MovieSet.ToList()
        Return View("Index", movies)
    End Function

End Class
