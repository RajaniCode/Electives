Public Class TheaterController
    Inherits Controller

    Private _entities As New MoviesDBEntities()

    Public Function Index() As ActionResult
        Return View(_entities.MovieSet.ToList())
    End Function

End Class
