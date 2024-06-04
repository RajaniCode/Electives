Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc
Imports MvcFakes

<TestClass()> _
 Public Class SimpleMovieControllerTests

    <TestMethod()> _
    Public Sub IndexAddsMoviesToCache()
        ' Arrange
        Dim cache = New FakeCache()
        Dim service = New SimpleMovieService(New FakeSimpleMovieRepository(), cache)
        Dim controller = New SimpleMovieController(service)

        ' Act
        controller.Index()

        ' Assert
        Assert.IsInstanceOfType(cache("movies"), GetType(IEnumerable(Of Movie)))
    End Sub

    <TestMethod()> _
    Public Sub IndexRetrievesMovieFromCache()
        ' Arrange movies
        Dim movies = New List(Of Movie)()
        movies.Add(Movie.CreateMovie(1, "Star Wars", "Lucas", DateTime.Parse("1/1/1977")))

        ' Arrange cache
        Dim cache = New FakeCache()
        cache("movies") = movies

        ' Arrange controller
        Dim service = New SimpleMovieService(New FakeSimpleMovieRepository(), cache)
        Dim controller = New SimpleMovieController(service)

        ' Act
        Dim results = CType(controller.Index(), ViewResult)

        ' Assert
        Dim movieResults = CType(results.ViewData.Model, List(Of Movie))
        CollectionAssert.AreEqual(movies, movieResults)
    End Sub

End Class