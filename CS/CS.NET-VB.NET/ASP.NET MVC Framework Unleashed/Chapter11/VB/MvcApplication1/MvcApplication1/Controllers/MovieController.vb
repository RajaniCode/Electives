Public Class MovieController
    Inherits Controller

    Private _entities As New MoviesDBEntities()

    <OutputCache(Duration:=9999, VaryByParam:="movieId")> _
    Public Function Details(ByVal movieId As Integer) As ActionResult
        Dim result = (From movie In _entities.MovieSet _
                      Where movie.Id = movieId _
                      Select movie).FirstOrDefault()
        Return View(result)
    End Function

End Class
