Public Class SimpleMovieController
    Inherits Controller

    Private _service As ISimpleMovieService

    Public Sub New()
        Me.New(New SimpleMovieService())
    End Sub

    Public Sub New(ByVal service As ISimpleMovieService)
        _service = service
    End Sub

    Public Function Index() As ActionResult
        Return View(_service.ListMoviesCached())
    End Function

End Class
