Imports UnleashedBlog

''' <summary>
''' Creates one repository and shares the single repository
''' with every controller. When testing, you should retrieve a 
''' controller from this controller factory.
''' </summary>
Public Class ControllerFactory
    Private _blogRepository As BlogRepositoryBase = New FakeBlogRepository()


    Public Function GetBlogController() As BlogController
        Return New BlogController(_blogRepository)
    End Function

    Public Function GetArchiveController() As ArchiveController
        Return New ArchiveController(_blogRepository)
    End Function


    Public Function GetCommentController() As CommentController
        Return New CommentController(_blogRepository)
    End Function


    Public Function GetApplicationController() As ApplicationController
        Return New ApplicationControllerChild(_blogRepository)
    End Function


End Class

Public Class ApplicationControllerChild
    Inherits ApplicationController
    Public Sub New(ByVal blogRepository As BlogRepositoryBase)
        MyBase.New(blogRepository)
    End Sub
End Class
