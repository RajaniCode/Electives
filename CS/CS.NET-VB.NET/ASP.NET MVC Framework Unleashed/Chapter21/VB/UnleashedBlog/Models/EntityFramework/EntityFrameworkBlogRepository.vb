''' <summary>
''' An implementation of the BlogRepository for the Microsoft Entity Framework.
''' </summary>
Public Class EntityFrameworkBlogRepository
    Inherits BlogRepositoryBase

    Private _entities As New BlogDBEntities()

    '___________________________________
    ' Blog entry methods
    '___________________________________



    ''' <summary>
    ''' Converts from an application Blog Entry 
    ''' to an Entity Framework BlogEntryEntity.
    ''' </summary>
    Private Function ConvertBlogEntryToBlogEntryEntity(ByVal entry As BlogEntry) As BlogEntryEntity
        Dim entity = New BlogEntryEntity()

        entity.Id = entry.Id
        entity.Author = entry.Author
        entity.Description = entry.Description
        entity.Name = entry.Name
        entity.DatePublished = entry.DatePublished
        entity.Text = entry.Text
        entity.Title = entry.Title
        Return entity
    End Function


    ''' <summary>
    ''' Returns blog entries from database
    ''' converting from Microsot Entity Framework blog entry entities
    ''' to application blog entries.
    ''' </summary>
    Protected Overrides Function QueryBlogEntries() As IQueryable(Of BlogEntry)
        Return From e In _entities.BlogEntryEntitySet _
               Select New BlogEntry With {.Id = e.Id, .Author = e.Author, .Description = e.Description, .Name = e.Name, .DateModified = e.DateModified, .DatePublished = e.DatePublished, .Text = e.Text, .Title = e.Title, .CommentCount = (From c In _entities.CommentEntitySet _
               Where c.BlogEntryId = e.Id Select c).Count()}
    End Function



    ''' <summary>
    ''' Adds a blog entry to the database.
    ''' </summary>
    Public Overrides Sub CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry)
        Dim entity = ConvertBlogEntryToBlogEntryEntity(blogEntryToCreate)

        _entities.AddToBlogEntryEntitySet(entity)
        _entities.SaveChanges()
    End Sub

    '__________________________
    ' Comment methods
    '___________________________


    ''' <summary>
    ''' Converts an application Comment to a Microsoft Entity Framework
    ''' Comment entity.
    ''' </summary>
    Private Function ConvertCommentToCommentEntity(ByVal comment As Comment) As CommentEntity
        Dim entity = New CommentEntity()

        entity.Id = comment.Id
        entity.BlogEntryId = comment.BlogEntryId
        entity.DatePublished = comment.DatePublished
        entity.Email = comment.Email
        entity.Name = comment.Name
        entity.Text = comment.Text
        entity.Title = comment.Title
        entity.Url = comment.Url
        Return entity
    End Function


    ''' <summary>
    ''' Retrieves comments from the database converting
    ''' instances of the Comment Entity class to instances
    ''' of the Comment class
    ''' </summary>
    Protected Overrides Function QueryComments() As IQueryable(Of Comment)
        Return From c In _entities.CommentEntitySet _
               Select New Comment With {.Id = c.Id, .BlogEntryId = c.BlogEntryId, .DatePublished = c.DatePublished, .Email = c.Email, .Name = c.Name, .Text = c.Text, .Title = c.Title, .Url = c.Url}
    End Function

    ''' <summary>
    ''' Adds a new comment to the database
    ''' </summary>
    Public Overrides Sub CreateComment(ByVal commentToCreate As Comment)
        Dim entity = ConvertCommentToCommentEntity(commentToCreate)

        _entities.AddToCommentEntitySet(entity)
        _entities.SaveChanges()
    End Sub

End Class
