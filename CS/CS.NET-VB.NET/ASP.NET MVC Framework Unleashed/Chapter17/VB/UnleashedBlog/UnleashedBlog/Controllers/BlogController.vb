Public Class BlogController
    Inherits System.Web.Mvc.Controller

    Private _repository As BlogRepositoryBase

    Public Sub New()
        Me.New(New EntityFrameworkBlogRepository())
    End Sub


    Public Sub New(ByVal repository As BlogRepositoryBase)
        _repository = repository
    End Sub


    Public Function Index() As ActionResult
        Return View(_repository.ListBlogEntries())
    End Function


    Public Function Create()
        Return View()
    End Function

    <AcceptVerbs(HttpVerbs.Post)> _
    Public Function Create(ByVal blogEntryToCreate As BlogEntry) As ActionResult
        _repository.CreateBlogEntry(blogEntryToCreate)

        Return RedirectToAction("Index")
    End Function

End Class
