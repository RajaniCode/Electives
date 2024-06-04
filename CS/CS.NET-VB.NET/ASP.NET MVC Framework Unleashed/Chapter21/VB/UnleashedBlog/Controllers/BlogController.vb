Public Class BlogController
    Inherits ApplicationController

    Public Sub New()
    End Sub

    Public Sub New(ByVal blogRepository As BlogRepositoryBase)
        MyBase.New(blogRepository)
    End Sub

    ''' <summary>
    ''' Returns a page of blog entries.
    ''' </summary>
    ''' <param name="page"></param>
    ''' <returns></returns>
    Public Function Index(ByVal page As Nullable(Of Integer)) As ActionResult
        Return View(_blogService.ListBlogEntries(page))
    End Function

    ''' <summary>
    ''' Only callable within an Ajax request. 
    ''' Returns a page of blog entries.
    ''' </summary>
    <AcceptAjax(), ActionName("Index")> _
    Public Function Index_Ajax(ByVal page As Nullable(Of Integer)) As ActionResult
        Return PartialView("BlogEntries", _blogService.ListBlogEntries(page))
    End Function

    ''' <summary>
    ''' Displays the HTML form for creating a new blog entry.
    ''' </summary>
    Public Function Create() As ActionResult
        Return View()
    End Function

    ''' <summary>
    ''' Enables you to create a new blog entry.
    ''' </summary>
    <AcceptVerbs(HttpVerbs.Post), ValidateInput(False)> _
    Public Function Create(<Bind(Exclude:="Id")> ByVal blogEntryToCreate As BlogEntry) As ActionResult
        If _blogService.CreateBlogEntry(blogEntryToCreate) = False Then
            Return View()
        End If

        Return RedirectToAction("Index")
    End Function


End Class
