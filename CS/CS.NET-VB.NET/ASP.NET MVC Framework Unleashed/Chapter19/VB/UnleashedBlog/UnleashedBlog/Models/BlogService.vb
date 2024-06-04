Public Class BlogService
    Inherits BlogServiceBase

    Public Sub New(ByVal modelState As ModelStateDictionary)
        MyBase.New(modelState, New EntityFrameworkBlogRepository())
    End Sub

    Public Sub New(ByVal modelState As ModelStateDictionary, ByVal blogRepository As BlogRepositoryBase)
        MyBase.New(modelState, blogRepository)
    End Sub


    Public Overrides Function ListBlogEntries() As IEnumerable(Of BlogEntry)
        Return _blogRepository.ListBlogEntries()
    End Function


    Public Overrides Function ListBlogEntries(ByVal year As Nullable(Of Integer), ByVal month As Nullable(Of Integer), ByVal day As Nullable(Of Integer), ByVal name As String) As IEnumerable(Of BlogEntry)
        Return _blogRepository.ListBlogEntries(year, month, day, name)
    End Function


    Public Overrides Function CreateBlogEntry(ByVal blogEntryToCreate As BlogEntry) As Boolean
        ' validation
        If blogEntryToCreate.Title.Trim().Length = 0 Then
            _modelState.AddModelError("Title", "Title is required.")
        End If
        If blogEntryToCreate.Title.Length > 500 Then
            _modelState.AddModelError("Title", "Title is too long.")
        End If
        If blogEntryToCreate.Text.Trim().Length = 0 Then
            _modelState.AddModelError("Text", "Text is required.")
        End If
        If _modelState.IsValid = False Then
            Return False
        End If

        ' Business Rules
        If String.IsNullOrEmpty(blogEntryToCreate.Name) Then
            blogEntryToCreate.Name = blogEntryToCreate.Title
        End If
        blogEntryToCreate.Name = blogEntryToCreate.Name.Replace(" ", "-")
        blogEntryToCreate.Name = Regex.Replace(blogEntryToCreate.Name, "[""$&+,/:;=?@]", String.Empty)

        ' Data access
        _blogRepository.CreateBlogEntry(blogEntryToCreate)
        Return True
    End Function

End Class
