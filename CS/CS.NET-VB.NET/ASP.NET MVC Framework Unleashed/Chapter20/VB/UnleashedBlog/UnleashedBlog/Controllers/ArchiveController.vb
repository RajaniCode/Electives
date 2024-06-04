Imports UnleashedBlog.Attributes

Public Class ArchiveController
    Inherits Controller

    Private _blogService As BlogServiceBase

    Public Sub New()
        _blogService = New BlogService(Me.ModelState)
    End Sub

    Public Sub New(ByVal blogRepository As BlogRepositoryBase)
        _blogService = New BlogService(Me.ModelState, blogRepository)
    End Sub

    Public Function Index(ByVal page As Integer?, ByVal year As Integer?, ByVal month As Integer?, ByVal day As Integer?, ByVal name As String) As ActionResult
        Return View(_blogService.ListBlogEntries(page, year, month, day, name))
    End Function

    <AcceptAjax(), ActionName("Index")> _
    Public Function Index_Ajax(ByVal page As Integer?, ByVal year As Integer?, ByVal month As Integer?, ByVal day As Integer?, ByVal name As String) As ActionResult
        Return PartialView("BlogEntries", _blogService.ListBlogEntries(page, year, month, day, name))
    End Function

End Class
