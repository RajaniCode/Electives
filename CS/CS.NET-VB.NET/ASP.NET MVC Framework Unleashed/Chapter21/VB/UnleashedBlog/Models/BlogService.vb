Public Class BlogService
    Inherits BlogServiceBase

    Public Sub New(ByVal modelState As ModelStateDictionary)
        MyBase.New(modelState, New EntityFrameworkBlogRepository())
    End Sub

    Public Sub New(ByVal modelState As ModelStateDictionary, ByVal blogRepository As BlogRepositoryBase)
        MyBase.New(modelState, blogRepository)
    End Sub



    Public Overrides Function GetBlogEntry(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal name As String) As BlogEntry
        Return _blogRepository.GetBlogEntry(year, month, day, name)
    End Function

    Public Overrides Function GetBlogEntry(ByVal id As Integer) As BlogEntry
        Return _blogRepository.GetBlogEntry(id)
    End Function

    Public Overrides Function ListBlogEntries(ByVal page As Integer?) As PagedList(Of BlogEntry)
        Return _blogRepository.ListBlogEntries(page, Nothing, Nothing, Nothing)
    End Function


    Public Overrides Function ListBlogEntries(ByVal page As Integer?, ByVal year As Integer?, ByVal month As Integer?, ByVal day As Integer?) As PagedList(Of BlogEntry)
        Return _blogRepository.ListBlogEntries(page, year, month, day)
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
        If blogEntryToCreate.Author.Trim().Length = 0 Then
            _modelState.AddModelError("Author", "Author is required.")
        End If
        If blogEntryToCreate.Description.Trim().Length = 0 Then
            _modelState.AddModelError("Description", "Description is required.")
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

        If blogEntryToCreate.DatePublished = DateTime.MinValue Then
            blogEntryToCreate.DatePublished = DateTime.Now
        End If

        ' Data access
        _blogRepository.CreateBlogEntry(blogEntryToCreate)
        Return True
    End Function

    ' Comment Methods

    Public Overrides Function CreateComment(ByVal commentToCreate As Comment) As Boolean
        ' Validation
        If commentToCreate.Title.Trim().Length = 0 Then
            _modelState.AddModelError("Title", "Title is required.")
        End If
        If commentToCreate.Name.Trim().Length = 0 Then
            _modelState.AddModelError("Name", "Name is required.")
        End If
        If commentToCreate.Text.Trim().Length = 0 Then
            _modelState.AddModelError("Text", "Comment is required.")
        End If
        If _modelState.IsValid = False Then
            Return False
        End If

        ' Business rules
        If commentToCreate.DatePublished = DateTime.MinValue Then
            commentToCreate.DatePublished = DateTime.Now
        End If

        ' Data access
        _blogRepository.CreateComment(commentToCreate)
        Return True
    End Function


    ' Archive Info methods
    Public Overrides Function ListBlogEntriesByMonth() As IList(Of ArchiveInfo)
        Return CType(_blogRepository.ListBlogEntriesByMonth(), IList(Of ArchiveInfo))
    End Function

End Class
