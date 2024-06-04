Public Class MovieRepositoryController
    Inherits Controller

    Private _repository As MovieRepositoryBase

    Public Sub New()
        Me.New(New MovieRepository())
    End Sub

    Public Sub New(ByVal repository As MovieRepositoryBase)
        _repository = repository
    End Sub


    Public Function Index() As ActionResult
        Return View(_repository.ListMoviesCached())
    End Function


    Public Function Create() As ActionResult
        Return View()
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Create(<Bind(Exclude:="Id")> ByVal movieToCreate As Movie) As ActionResult
        If (Not ModelState.IsValid) Then
            Return View()
        End If
        _repository.CreateMovie(movieToCreate)
        Return RedirectToAction("Index")
    End Function


End Class
