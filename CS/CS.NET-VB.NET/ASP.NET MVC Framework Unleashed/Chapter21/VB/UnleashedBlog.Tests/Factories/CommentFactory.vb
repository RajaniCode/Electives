''' <summary>
''' The Comment Factory creates comments. Because we might
''' change the properties of a comment, creating comments
''' at one central location makes our tests easier to change.
''' </summary>
Public Class CommentFactory
    Public Shared Function [Get]() As Comment
        Dim commentToCreate = New Comment()
        commentToCreate.BlogEntryId = 1
        commentToCreate.Title = "New Comment"
        commentToCreate.DatePublished = New DateTime(2010, 12, 25)
        commentToCreate.Url = "http://myblog.com"
        commentToCreate.Name = "Bob"
        commentToCreate.Email = "Bob@somewhere.com"
        commentToCreate.Text = "Here is the comment"
        Return commentToCreate
    End Function


    Public Shared Function GetWithTitle(ByVal blogEntryId As Integer, ByVal title As String) As Comment
        Dim commentToCreate = [Get]()
        commentToCreate.BlogEntryId = blogEntryId
        commentToCreate.Title = title
        Return commentToCreate
    End Function


    Public Shared Function GetWithName(ByVal blogEntryId As Integer, ByVal name As String) As Comment
        Dim commentToCreate = [Get]()
        commentToCreate.BlogEntryId = blogEntryId
        commentToCreate.Name = name
        Return commentToCreate
    End Function

    Public Shared Function GetWithText(ByVal blogEntryId As Integer, ByVal text As String) As Comment
        Dim commentToCreate = [Get]()
        commentToCreate.BlogEntryId = blogEntryId
        commentToCreate.Text = text
        Return commentToCreate
    End Function


End Class

