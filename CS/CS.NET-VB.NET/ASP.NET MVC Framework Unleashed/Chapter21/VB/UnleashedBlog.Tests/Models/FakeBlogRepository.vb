''' <summary>
''' This is the fake blog repository used during testing. The
''' fake blog repository stores data items in memory.
''' </summary>
Public Class FakeBlogRepository
    Inherits BlogRepositoryBase

    Private _blogEntries As List(Of BlogEntry) = New List(Of BlogEntry)()
    Private _comments As List(Of Comment) = New List(Of Comment)()

    ' Blog Entry methods

    Protected Overrides Function QueryBlogEntries() As IQueryable(Of BlogEntry)
        Return From e In _blogEntries.AsQueryable() _
               Select New BlogEntry With {.Id = e.Id, .Author = e.Author, .Description = e.Description, .Name = e.Name, .DateModified = e.DateModified, .DatePublished = e.DatePublished, .Text = e.Text, .Title = e.Title, .CommentCount = (From c In _comments.AsQueryable() _
               Where c.BlogEntryId = e.Id Select c).Count()}
    End Function


    Public Overrides Sub CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry)
        _blogEntries.Add(blogEntryToCreate)
    End Sub

    ' Comment methods

    Protected Overrides Function QueryComments() As IQueryable(Of Comment)
        Return _comments.AsQueryable()
    End Function

    Public Overrides Sub CreateComment(ByVal commentToCreate As Comment)
        _comments.Add(commentToCreate)
    End Sub


End Class
