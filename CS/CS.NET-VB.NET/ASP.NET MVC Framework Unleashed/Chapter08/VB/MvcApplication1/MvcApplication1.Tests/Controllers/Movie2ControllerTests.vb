Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
    Public Class Movie2ControllerTests

    <TestMethod()> _
    Public Sub DirectorRequired()
        ' Arrange
        Dim modelState = New ModelStateDictionary()
        Dim service = New MovieService(modelState, New FakeMovieRepository())
        Dim controller = New Movie2Controller(service)
        Dim movieToCreate = Movie.CreateMovie(0, "Star Wars", String.Empty, DateTime.Parse("1/1/1977"))

        ' Act
        controller.Create(movieToCreate)

        ' Assert
        Assert.IsTrue(HasErrorMessage(modelState("Director"), "Director is required."))
    End Sub


    Private Function HasErrorMessage(ByVal modelState As ModelState, ByVal errorMessage As String) As Boolean
        For Each modelError In modelState.Errors
            If modelError.ErrorMessage = errorMessage Then
                Return True
            End If
        Next
        Return False
    End Function


End Class
