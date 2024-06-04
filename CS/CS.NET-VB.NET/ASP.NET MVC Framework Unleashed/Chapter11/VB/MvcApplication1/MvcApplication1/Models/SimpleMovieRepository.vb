Public Class SimpleMovieRepository
    Implements ISimpleMovieRepository

    Private _entities As New MoviesDBEntities()

    Public Function ListMovies() As IEnumerable(Of Movie) Implements ISimpleMovieRepository.ListMovies
        Return _entities.MovieSet.ToList()
    End Function

End Class
