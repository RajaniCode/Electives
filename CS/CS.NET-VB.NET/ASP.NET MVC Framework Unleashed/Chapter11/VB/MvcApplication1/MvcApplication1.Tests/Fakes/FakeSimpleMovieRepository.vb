
Public Class FakeSimpleMovieRepository
    Implements ISimpleMovieRepository

    Public Function ListMovies() As IEnumerable(Of Movie) Implements ISimpleMovieRepository.ListMovies
        Dim movies = New List(Of Movie)()
        movies.Add(Movie.CreateMovie(1, "Star Wars", "Lucas", DateTime.Parse("1/1/1977")))
        movies.Add(Movie.CreateMovie(2, "King Kong", "Jackson", DateTime.Parse("1/1/2002")))
        movies.Add(Movie.CreateMovie(3, "Memento", "Nolan", DateTime.Parse("1/1/2005")))

        Return movies
    End Function
End Class
