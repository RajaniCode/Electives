
Public Class MovieRepository
    Inherits MovieRepositoryBase

    Private _entities As New MoviesDBEntities()
    Private _cache As Cache

    Public Sub New()
        _cache = HttpContext.Current.Cache
    End Sub


    Public Overrides Function ListMoviesCached() As IEnumerable(Of Movie)
        Dim movies = CType(_cache("movies"), IEnumerable(Of Movie))
        If movies Is Nothing Then
            movies = ListMovies()
            _cache("movies") = movies
        End If
        Return movies
    End Function


    Public Overrides Function ListMovies() As IEnumerable(Of Movie)
        Return _entities.MovieSet.ToList()
    End Function


    Public Overrides Sub CreateMovie(ByVal movieToCreate As Movie)
        _entities.AddToMovieSet(movieToCreate)
        _entities.SaveChanges()
        _cache.Remove("movies")
    End Sub
End Class
