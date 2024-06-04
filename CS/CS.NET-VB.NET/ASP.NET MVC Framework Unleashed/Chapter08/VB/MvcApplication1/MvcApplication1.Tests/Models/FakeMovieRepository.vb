Public Class FakeMovieRepository
    Implements IMovieRepository

    Public Function ListMovies() As IEnumerable(Of Movie) Implements IMovieRepository.ListMovies
        Return Nothing
    End Function

    Public Sub CreateMovie(ByVal movieToCreate As Movie) Implements IMovieRepository.CreateMovie
    End Sub

End Class
