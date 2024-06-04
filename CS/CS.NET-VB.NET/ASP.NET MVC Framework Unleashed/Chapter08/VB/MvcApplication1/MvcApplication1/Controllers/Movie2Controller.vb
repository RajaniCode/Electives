Public Class Movie2Controller
    Inherits Controller

    Private _service As IMovieService

    Sub New()
        _service = New MovieService(Me.ModelState)
    End Sub

    Sub New(ByVal service As IMovieService)
        _service = service
    End Sub

    Function Index() As ActionResult
        Return View(_service.ListMovies())
    End Function

    ' GET: /Movie/Create

    Function Create() As ActionResult
        Return View()
    End Function


    ' POST: /Movie/Create

    <AcceptVerbs(HttpVerbs.Post)> _
 Function Create(<Bind(Exclude:="Id")> ByVal movieToCreate As Movie) As ActionResult
        If _service.CreateMovie(movieToCreate) Then
            Return RedirectToAction("Index")
        End If
        Return View()
    End Function

End Class