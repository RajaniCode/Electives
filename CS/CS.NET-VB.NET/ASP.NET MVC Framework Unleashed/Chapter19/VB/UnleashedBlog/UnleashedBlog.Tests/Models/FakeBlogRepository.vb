Imports System.Collections.Generic
Imports System.Linq

Public Class FakeBlogRepository
    Inherits BlogRepositoryBase

    Private _blogEntries As New List(Of BlogEntry)

    Protected Overrides Function QueryBlogEntries() As IQueryable(Of BlogEntry)
        Return _blogEntries.AsQueryable
    End Function


    Public Overrides Function ListBlogEntries() As List(Of BlogEntry)
        Return Me.QueryBlogEntries().ToList()
    End Function

    Public Overrides Sub CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry)
        _blogEntries.Add(blogEntryToCreate)
    End Sub
End Class
