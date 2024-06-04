Imports MvcFakes

Public Class SimpleMovieService
    Implements ISimpleMovieService

    Private _repository As ISimpleMovieRepository
    Private _cache As ICache

    Public Sub New()
        Me.New(New SimpleMovieRepository(), New CacheWrapper(HttpContext.Current.Cache))
    End Sub

    Public Sub New(ByVal repository As ISimpleMovieRepository, ByVal cache As ICache)
        _repository = repository
        _cache = cache
    End Sub


    Public Function ListMoviesCached() As IEnumerable(Of Movie) Implements ISimpleMovieService.ListMoviesCached
        Dim movies = CType(_cache("movies"), IEnumerable(Of Movie))
        If movies Is Nothing Then
            movies = ListMovies()
            _cache("movies") = movies
        End If
        Return movies
    End Function


    Public Function ListMovies() As IEnumerable(Of Movie)
        Return _repository.ListMovies()
    End Function

End Class
