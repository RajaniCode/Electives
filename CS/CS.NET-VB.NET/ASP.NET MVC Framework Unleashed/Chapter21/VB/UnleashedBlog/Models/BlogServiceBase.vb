
Public MustInherit Class BlogServiceBase
    Protected _modelState As ModelStateDictionary
    Protected _blogRepository As BlogRepositoryBase

    Public Sub New(ByVal modelState As ModelStateDictionary, ByVal blogRepository As BlogRepositoryBase)
        _modelState = modelState
        _blogRepository = blogRepository
    End Sub

    ' Blog entry methods
    Public MustOverride Function GetBlogEntry(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal name As String) As BlogEntry
    Public MustOverride Function GetBlogEntry(ByVal id As Integer) As BlogEntry
    Public MustOverride Function ListBlogEntries(ByVal page As Integer?) As PagedList(Of BlogEntry)
    Public MustOverride Function ListBlogEntries(ByVal page As Integer?, ByVal year As Integer?, ByVal month As Integer?, ByVal day As Integer?) As PagedList(Of BlogEntry)
    Public MustOverride Function CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry) As Boolean

    ' Comment methods
    Public MustOverride Function CreateComment(ByVal commentToCreate As Comment) As Boolean

    ' Archive Info method
    Public MustOverride Function ListBlogEntriesByMonth() As IList(Of ArchiveInfo)

End Class
