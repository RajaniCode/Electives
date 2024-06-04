Public MustInherit Class BlogServiceBase

    Protected _modelState As ModelStateDictionary
    Protected _blogRepository As BlogRepositoryBase

    Public Sub New(ByVal modelState As ModelStateDictionary, ByVal blogRepository As BlogRepositoryBase)
        _modelState = modelState
        _blogRepository = blogRepository
    End Sub

    Public MustOverride Function ListBlogEntries() As IEnumerable(Of BlogEntry)
    Public MustOverride Function ListBlogEntries(ByVal year As Nullable(Of Integer), ByVal month As Nullable(Of Integer), ByVal day As Nullable(Of Integer), ByVal name As String) As IEnumerable(Of BlogEntry)
    Public MustOverride Function CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry) As Boolean


End Class
