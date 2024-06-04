Public Class CommentController
    Inherits Controller
    Private _blogService As BlogServiceBase

    Public Sub New()
        _blogService = New BlogService(Me.ModelState)
    End Sub

    Public Sub New(ByVal blogRepository As BlogRepositoryBase)
        _blogService = New BlogService(Me.ModelState, blogRepository)
    End Sub

    ''' <summary>
    ''' Enables you to create a new comment.
    ''' </summary>
    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Create(<Bind(Prefix:="Comment", Exclude:="Id")> ByVal commentToCreate As Comment) As ActionResult
        ' Attempt to add comment
        Dim success = _blogService.CreateComment(commentToCreate)
        Dim blogEntry = _blogService.GetBlogEntry(commentToCreate.BlogEntryId)

        If success Then
            Return RedirectToRoute("Details", New With {Key .year = blogEntry.DatePublished.Year, Key .month = blogEntry.DatePublished.Month, Key .day = blogEntry.DatePublished.Day, Key .name = blogEntry.Name})
        End If

        Return View("~/Views/Archive/Details.aspx", blogEntry)
    End Function

End Class
