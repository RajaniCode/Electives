Public Class ControllerFactory

    Private _blogRepository As BlogRepositoryBase = New FakeBlogRepository()


    Public Function GetBlogController() As BlogController
        Return New BlogController(_blogRepository)
    End Function

    Public Function GetArchiveController() As ArchiveController
        Return New ArchiveController(_blogRepository)
    End Function

End Class
