Public Class BlogController
    Inherits Controller

    Private _blogService As BlogServiceBase

    Public Sub New()
        _blogService = New BlogService(Me.ModelState)
    End Sub

    Public Sub New(ByVal blogRepository As BlogRepositoryBase)
        _blogService = New BlogService(Me.ModelState, blogRepository)
    End Sub

    Public Function Index() As ActionResult
        Return View(_blogService.ListBlogEntries())
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
