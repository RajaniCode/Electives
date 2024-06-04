Public Class ArchiveController
    Inherits Controller

    Private _repository As BlogRepositoryBase

    Public Sub New()
        Me.New(New EntityFrameworkBlogRepository())
    End Sub

    Public Sub New(ByVal repository As BlogRepositoryBase)
        _repository = repository
    End Sub

    Public Function Index(ByVal year As Integer?, ByVal month As Integer?, ByVal day As Integer?, ByVal name As String) As ActionResult
        Return View(_repository.ListBlogEntries(year, month, day, name))
    End Function

End Class
