Public Class SlidingController
    Inherits Controller

    Private _entities As New MoviesDBEntities()

    Public Function Details(ByVal id As Integer) As ActionResult
        Dim cache = Me.HttpContext.Cache
        Dim key = GetMovieCacheKey(id)
        Dim movie = CType(cache(key), Movie)


        If movie IsNot Nothing Then
            Debug.WriteLine("Got movie from cache")
        Else
            Debug.WriteLine("Getting movie from database")
            movie = (From m In _entities.MovieSet _
                     Where m.Id = id _
                     Select m).FirstOrDefault()
            cache.Insert(key, movie, Nothing, cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10))
        End If

        Return View(movie)
    End Function


    Private Function GetMovieCacheKey(ByVal movieId As Integer) As String
        Return "movie" & movieId.ToString()
    End Function

End Class
