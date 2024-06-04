Public Class MovieService
    Implements IMovieService

    Private _modelState As ModelStateDictionary
    Private _repository As IMovieRepository

    Public Sub New(ByVal modelState As ModelStateDictionary)
        Me.New(modelState, New MovieRepository())
    End Sub

    Public Sub New(ByVal modelState As ModelStateDictionary, ByVal repository As IMovieRepository)
        _modelState = modelState
        _repository = repository
    End Sub

    Public Function ListMovies() As IEnumerable(Of Movie) Implements IMovieService.ListMovies
        Return _repository.ListMovies()
    End Function

    Public Function CreateMovie(ByVal movieToCreate As Movie) As Boolean Implements IMovieService.CreateMovie
        ' validate
        If movieToCreate.Title.Trim().Length = 0 Then
            _modelState.AddModelError("Title", "Title is required.")
        End If
        If movieToCreate.Title.IndexOf("r") > 0 Then
            _modelState.AddModelError("Title", "Title cannot contain the letter r.")
        End If
        If movieToCreate.Director.Trim().Length = 0 Then
            _modelState.AddModelError("Director", "Director is required.")
        End If
        If (Not _modelState.IsValid) Then
            Return False
        End If

        _repository.CreateMovie(movieToCreate)
        Return True
    End Function
End Class


Public Interface IMovieService
    Function ListMovies() As IEnumerable(Of Movie)
    Function CreateMovie(ByVal movieToCreate As Movie) As Boolean
End Interface

