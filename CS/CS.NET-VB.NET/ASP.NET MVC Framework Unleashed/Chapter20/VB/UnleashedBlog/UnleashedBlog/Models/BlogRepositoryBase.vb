Imports System.Collections.Generic
Imports System.Linq

Public MustInherit Class BlogRepositoryBase

    ' Blog Entry Methods
    Public MustOverride Sub CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry)
    Protected MustOverride Function QueryBlogEntries() As IQueryable(Of BlogEntry)

    Public Overridable Function ListBlogEntries(ByVal page As Integer?, ByVal year As Integer?, ByVal month As Integer?, ByVal day As Integer?, ByVal name As String) As PagedList(Of BlogEntry)
        Dim query = Me.QueryBlogEntries()
        If year.HasValue Then
            query = query.Where(Function(e) e.DatePublished.Year = year.Value)
        End If
        If month.HasValue Then
            query = query.Where(Function(e) e.DatePublished.Month = month.Value)
        End If
        If day.HasValue Then
            query = query.Where(Function(e) e.DatePublished.Day = day.Value)
        End If
        If Not String.IsNullOrEmpty(name) Then
            query = query.Where(Function(e) e.Name = name)
        End If
        Return query.OrderByDescending(Function(e) e.DatePublished).ToPagedList(page, 5)
    End Function

End Class
