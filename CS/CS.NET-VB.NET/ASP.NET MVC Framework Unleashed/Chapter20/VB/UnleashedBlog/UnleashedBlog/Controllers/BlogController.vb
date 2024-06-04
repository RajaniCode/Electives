Imports UnleashedBlog.Attributes

Public Class BlogController
    Inherits Controller

    Private _blogService As BlogServiceBase

    Public Sub New()
        _blogService = New BlogService(Me.ModelState)
    End Sub

    Public Sub New(ByVal blogRepository As BlogRepositoryBase)
        _blogService = New BlogService(Me.ModelState, blogRepository)
    End Sub

    Public Function Index(ByVal page As Integer?) As ActionResult
        Return View(_blogService.ListBlogEntries(page))
    End Function

    <AcceptAjax(), ActionName("Index")> _
    Public Function Index_Ajax(ByVal page As Integer?) As ActionResult
        Return PartialView("BlogEntries", _blogService.ListBlogEntries(page))
    End Function

    Public Function Create() As ActionResult
        Return View()
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Create(<Bind(Exclude:="Id")> ByVal blogEntryToCreate As BlogEntry) As ActionResult
        If Not _blogService.CreateBlogEntry(blogEntryToCreate) Then
            Return View()
        End If

        Return RedirectToAction("Index")
    End Function
End Class
