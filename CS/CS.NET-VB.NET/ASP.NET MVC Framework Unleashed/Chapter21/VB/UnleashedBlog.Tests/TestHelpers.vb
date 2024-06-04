Imports System.Web.Mvc

Friend Class TestHelpers

    ''' <summary>
    ''' Enables you to create a large set of blog entries for
    ''' testing purposes.
    ''' </summary>
    Public Shared Sub CreateBlogEntries(ByVal controller As BlogController, ByVal count As Integer)
        For i As Integer = 0 To count - 1
            Dim name = "Blog Entry " & i.ToString()
            Dim blogEntryToCreate = BlogEntryFactory.GetWithName(name)
            controller.Create(blogEntryToCreate)
        Next i
    End Sub

    ''' <summary>
    ''' Enables you to check whether a particular error message can
    ''' be found in the model state errors collection.
    ''' </summary>
    Public Shared Function HasErrorMessage(ByVal modelState As ModelState, ByVal errorMessage As String) As Boolean
        For Each modelError In modelState.Errors
            If modelError.ErrorMessage = errorMessage Then
                Return True
            End If
        Next
        Return False
    End Function

    ''' <summary>
    ''' Create a new blog entry
    ''' </summary>
    Public Shared Function CreateBlogEntry(ByVal controllerFactory As ControllerFactory) As BlogEntry
        Dim blogController = controllerFactory.GetBlogController()
        Dim blogEntryToCreate = BlogEntryFactory.Get()
        blogController.Create(blogEntryToCreate)
        Return blogEntryToCreate
    End Function


    ''' <summary>
    ''' Creates a new comment for a blog entry.
    ''' </summary>
    Public Shared Function CreateComment(ByVal commentController As CommentController, ByVal blogEntry As BlogEntry, ByVal commentTitle As String, ByVal commentDatePublished As DateTime) As Comment
        ' Create comment
        Dim commentToCreate = CommentFactory.Get()
        commentToCreate.BlogEntryId = blogEntry.Id
        commentToCreate.Title = commentTitle
        commentToCreate.DatePublished = commentDatePublished

        ' Add to blog entry
        commentController.Create(commentToCreate)

        Return commentToCreate
    End Function



End Class
