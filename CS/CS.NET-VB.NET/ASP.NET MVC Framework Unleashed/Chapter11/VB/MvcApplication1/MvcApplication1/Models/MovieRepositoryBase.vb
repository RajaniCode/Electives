Public MustInherit Class MovieRepositoryBase

    Public MustOverride Function ListMoviesCached() As IEnumerable(Of Movie)
    Public MustOverride Function ListMovies() As IEnumerable(Of Movie)
    Public MustOverride Sub CreateMovie(ByVal movieToCreate As Movie)

End Class
