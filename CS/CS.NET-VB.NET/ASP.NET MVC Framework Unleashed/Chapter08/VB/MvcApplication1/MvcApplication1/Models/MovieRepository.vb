Public Class MovieRepository
    Implements IMovieRepository

    Private _entities As New MoviesDBEntities()

    Public Function ListMovies() As IEnumerable(Of Movie) Implements IMovieRepository.ListMovies
        Return _entities.MovieSet.ToList()
    End Function

    Public Sub CreateMovie(ByVal movieToCreate As Movie) Implements IMovieRepository.CreateMovie
        _entities.AddToMovieSet(movieToCreate)
        _entities.SaveChanges()
    End Sub
End Class

Public Interface IMovieRepository
    Function ListMovies() As IEnumerable(Of Movie)
    Sub CreateMovie(ByVal movieToCreate As Movie)
End Interface
