
Public Class ArchiveController
    Inherits ApplicationController
    Public Sub New()
    End Sub

    Public Sub New(ByVal blogRepository As BlogRepositoryBase)
        MyBase.New(blogRepository)
    End Sub


    ''' <summary>
    ''' Returns a single blog entry
    ''' </summary>
    Public Function Details(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, ByVal name As String) As ActionResult
        Return View(_blogService.GetBlogEntry(year, month, day, name))
    End Function

    ''' <summary>
    ''' Returns a list of blog entries that match a specified year, month, or day
    ''' </summary>
    Public Function Index(ByVal page As Nullable(Of Integer), ByVal year As Nullable(Of Integer), ByVal month As Nullable(Of Integer), ByVal day As Nullable(Of Integer)) As ActionResult
        Return View(_blogService.ListBlogEntries(page, year, month, day))
    End Function

    ''' <summary>
    ''' Only callable within an Ajax request.
    ''' Returns a list of blog entries that match a specified year, month, or day.
    ''' </summary>
    <AcceptAjax(), ActionName("Index")> _
    Public Function Index_Ajax(ByVal page As Nullable(Of Integer), ByVal year As Nullable(Of Integer), ByVal month As Nullable(Of Integer), ByVal day As Nullable(Of Integer)) As ActionResult
        Return PartialView("BlogEntries", _blogService.ListBlogEntries(page, year, month, day))
    End Function


End Class
