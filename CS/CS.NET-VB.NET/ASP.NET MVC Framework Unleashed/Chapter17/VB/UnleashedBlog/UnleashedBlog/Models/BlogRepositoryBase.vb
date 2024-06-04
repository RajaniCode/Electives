Imports System.Collections.Generic
Imports System.Linq

Public MustInherit Class BlogRepositoryBase

    ' Blog Entry Methods
    Public MustOverride Function ListBlogEntries() As List(Of BlogEntry)
    Public MustOverride Sub CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry)
    Protected MustOverride Function QueryBlogEntries() As IQueryable(Of BlogEntry)

End Class
