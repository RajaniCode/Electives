
Public MustInherit Class ApplicationController
    Inherits Controller

    Protected _blogService As BlogServiceBase

    Public Sub New()
        Me.New(New EntityFrameworkBlogRepository())
    End Sub


    Public Sub New(ByVal blogRepository As BlogRepositoryBase)
        _blogService = New BlogService(Me.ModelState, blogRepository)

        ViewData("ArchiveInfo") = _blogService.ListBlogEntriesByMonth()
    End Sub


End Class
