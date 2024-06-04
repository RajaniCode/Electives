Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc
Imports System.Collections
Imports System.Text.RegularExpressions

<TestClass()> _
    Public Class BlogControllerTests

    Private _controllerFactory As ControllerFactory
    Private _blogController As BlogController

    <TestInitialize()> _
    Public Sub Initialize()
        _controllerFactory = New ControllerFactory()
        _blogController = _controllerFactory.GetBlogController()
    End Sub


    <TestMethod()> _
    Public Sub ShowNewBlogEntries()
        ' Act
        Dim result As ViewResult = _blogController.Index(Nothing)

        ' Assert
        CollectionAssert.AllItemsAreInstancesOfType(result.ViewData.Model, GetType(BlogEntry))
    End Sub


    <TestMethod()> _
    Public Sub CreateBlogEntry()
        ' Arrange
        Dim blogEntryToCreate = BlogEntryFactory.Get()

        ' Act
        _blogController.Create(blogEntryToCreate)
        Dim result As ViewResult = _blogController.Index(Nothing)

        ' Assert
        Dim firstEntry = CType(result.ViewData.Model, IList)(0)
        Assert.AreSame(blogEntryToCreate, firstEntry)
    End Sub



    Private Function HasErrorMessage(ByVal modelState As ModelState, ByVal errorMessage As String) As Boolean
        For Each modelError In modelState.Errors
            If modelError.ErrorMessage = errorMessage Then
                Return True
            End If
        Next
        Return False
    End Function




    <TestMethod()> _
    Public Sub CreateTextRequired()
        ' Arrange 
        Dim blogEntryToCreate = BlogEntryFactory.GetWithText(String.Empty)

        ' Act
        Dim result As ViewResult = _blogController.Create(blogEntryToCreate)

        ' Assert
        Dim titleState = result.ViewData.ModelState("Text")
        Assert.IsTrue(HasErrorMessage(titleState, "Text is required."))
    End Sub


    <TestMethod()> _
    Public Sub CreateTitleRequired()
        ' Arrange 
        Dim blogEntryToCreate = BlogEntryFactory.GetWithTitle(String.Empty)

        ' Act
        Dim result As ViewResult = _blogController.Create(blogEntryToCreate)

        ' Assert
        Dim titleState = result.ViewData.ModelState("Title")
        Assert.IsTrue(HasErrorMessage(titleState, "Title is required."))
    End Sub


    <TestMethod()> _
    Public Sub CreateTitleMaximumLength500()
        ' Arrange
        Dim blogEntryToCreate = BlogEntryFactory.GetWithTitle("a".PadRight(501))

        ' Act
        Dim result As ViewResult = _blogController.Create(blogEntryToCreate)

        ' Assert
        Dim titleState = result.ViewData.ModelState("Title")
        Assert.IsTrue(HasErrorMessage(titleState, "Title is too long."))
    End Sub



    <TestMethod()> _
    Public Sub CreateNameIsValid()
        ' Arrange
        _blogController.Create(BlogEntryFactory.GetWithName("My Summer Vacation"))
        _blogController.Create(BlogEntryFactory.GetWithName("$&+,/:;=?@"))
        _blogController.Create(BlogEntryFactory.GetWithName("He said ""what?"""))

        ' Act
        Dim result As ViewResult = _blogController.Index(Nothing)

        ' Assert
        Dim blogEntries = CType(result.ViewData.Model, IList(Of BlogEntry))
        For Each entry In blogEntries
            StringAssert.DoesNotMatch(entry.Name, New Regex("[""$&+,/:;=?@]"))
        Next entry
    End Sub


    <TestMethod()> _
    Public Sub CreateNameFromTitle()
        ' Arrange
        Dim blogEntryToCreate = BlogEntryFactory.Get()
        blogEntryToCreate.Title = "TheTitle"
        blogEntryToCreate.Name = String.Empty

        Dim aController = _controllerFactory.GetArchiveController()

        ' Act
        _blogController.Create(blogEntryToCreate)
        Dim result As ViewResult = aController.Index(Nothing, Nothing, Nothing, Nothing, "TheTitle")

        ' Assert
        Dim blogEntries As IList(Of BlogEntry) = result.ViewData.Model
        Assert.AreEqual(1, blogEntries.Count)
    End Sub

    ' Paging

    <TestMethod()> _
    Public Sub IndexAcceptsPage()
        ' Act
        Dim result = CType(_blogController.Index(0), ViewResult)
    End Sub


    <TestMethod()> _
    Public Sub IndexReturnsPagedListForPage()
        ' Arrange
        CreateBlogEntries(50)

        ' Act
        Dim result = CType(_blogController.Index(2), ViewResult)

        ' Assert
        Dim page = CType(result.ViewData.Model, PagedList(Of BlogEntry))
        Assert.AreEqual(2, page.PageIndex)
    End Sub


    <TestMethod()> _
    Public Sub IndexReturnsLessThan6BlogEntries()
        ' Arrange
        CreateBlogEntries(20)

        ' Act
        Dim result = CType(_blogController.Index(0), ViewResult)

        ' Assert
        Dim page = CType(result.ViewData.Model, PagedList(Of BlogEntry))
        Assert.IsTrue(page.Count < 6)
    End Sub


    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesInOrderOfDatePublished()
        ' Arrange
        Dim blogEntry1 = BlogEntryFactory.GetWithDatePublished(New DateTime(2005, 12, 25))
        _blogController.Create(blogEntry1)
        Dim blogEntry2 = BlogEntryFactory.GetWithDatePublished(New DateTime(2005, 12, 26))
        _blogController.Create(blogEntry2)

        ' Act
        Dim result = CType(_blogController.Index(0), ViewResult)

        ' Assert
        Dim page = CType(result.ViewData.Model, PagedList(Of BlogEntry))
        Assert.AreSame(blogEntry2, page(0))
    End Sub


    Private Sub CreateBlogEntries(ByVal count As Integer)
        For i As Integer = 0 To count - 1
            Dim name = "Blog Entry " & i.ToString()
            Dim blogEntryToCreate = BlogEntryFactory.GetWithName(name)
            _blogController.Create(blogEntryToCreate)
        Next i
    End Sub

    ' Ajax tests

    <TestMethod()> _
    Public Sub Index_AjaxReturnsPartialViewResult()
        ' Act
        Dim result = _blogController.Index_Ajax(0)

        ' Assert
        Assert.IsInstanceOfType(result, GetType(PartialViewResult))
    End Sub

End Class
