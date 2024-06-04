Public Class EntityFrameworkBlogRepository
    Inherits BlogRepositoryBase

    Private _entities As New BlogDBEntities()

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

    Protected Overrides Function QueryBlogEntries() As IQueryable(Of BlogEntry)
        Return From e In _entities.BlogEntryEntitySet _
               Select New BlogEntry With {.Id = e.Id, _
                                          .Author = e.Author, _
                                          .Description = e.Description, _
                                          .Name = e.Name, _
                                          .DateModified = e.DateModified, _
                                          .DatePublished = e.DatePublished, _
                                          .Text = e.Text, _
                                          .Title = e.Title}
    End Function

    Public Overrides Function ListBlogEntries() As List(Of BlogEntry)
        Return QueryBlogEntries().ToList()
    End Function

    Public Overrides Sub CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry)
        Dim entity = ConvertBlogEntryToBlogEntryEntity(blogEntryToCreate)

        _entities.AddToBlogEntryEntitySet(entity)
        _entities.SaveChanges()
    End Sub

End Class
