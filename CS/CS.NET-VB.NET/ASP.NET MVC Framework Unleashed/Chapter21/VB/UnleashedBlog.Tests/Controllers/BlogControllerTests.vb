Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc
Imports System.Text.RegularExpressions

<TestClass()> _
 Public Class BlogControllerTests
    Private _controllerFactory As ControllerFactory
    Private _blogController As BlogController

    ''' <summary>
    ''' Because we are testing the Blog controller, let's just create
    ''' one before each test automatically.
    ''' </summary>
    <TestInitialize()> _
    Public Sub Initialize()
        _controllerFactory = New ControllerFactory()
        _blogController = _controllerFactory.GetBlogController()
    End Sub

    ''' <summary>
    ''' Tests that the Blog controller returns a list of blog entries.
    ''' </summary>
    <TestMethod()> _
    Public Sub ShowNewBlogEntries()
        ' Act
        Dim result As ViewResult = _blogController.Index(Nothing)

        ' Assert
        CollectionAssert.AllItemsAreInstancesOfType(result.ViewData.Model, GetType(BlogEntry))
    End Sub

    ''' <summary>
    ''' Verifies that you can create and then retrieve a new blog entry.
    ''' </summary>
    <TestMethod()> _
    Public Sub CreateBlogEntry()
        ' Arrange
        Dim blogEntryToCreate = BlogEntryFactory.GetWithName("Test")

        ' Act
        _blogController.Create(blogEntryToCreate)
        Dim result As ViewResult = _blogController.Index(Nothing)

        ' Assert
        Dim firstEntry = CType(result.ViewData.Model, List(Of BlogEntry))(0)
        Assert.AreEqual("Test", firstEntry.Name)
    End Sub


    '__________________________
    ' Validation Tests
    '__________________________


    ''' <summary>
    ''' Verifies that a missing Title property generates a validation error message.
    ''' </summary>
    <TestMethod()> _
    Public Sub CreateTitleRequired()
        ' Arrange 
        Dim blogEntryToCreate = BlogEntryFactory.GetWithTitle(String.Empty)

        ' Act
        Dim result As ViewResult = _blogController.Create(blogEntryToCreate)

        ' Assert
        Dim titleState = result.ViewData.ModelState("Title")
        Assert.IsTrue(TestHelpers.HasErrorMessage(titleState, "Title is required."))
    End Sub


    ''' <summary>
    ''' Verifies that a missing Author property generates a validation error message.
    ''' </summary>
    <TestMethod()> _
    Public Sub CreateAuthorRequired()
        ' Arrange 
        Dim blogEntryToCreate = BlogEntryFactory.GetWithAuthor(String.Empty)

        ' Act
        Dim result As ViewResult = _blogController.Create(blogEntryToCreate)

        ' Assert
        Dim authorState = result.ViewData.ModelState("Author")
        Assert.IsTrue(TestHelpers.HasErrorMessage(authorState, "Author is required."))
    End Sub

    ''' <summary>
    ''' Verifies that a missing Description property generates a validation error message.
    ''' </summary>
    <TestMethod()> _
    Public Sub CreateDescriptionRequired()
        ' Arrange 
        Dim blogEntryToCreate = BlogEntryFactory.GetWithDescription(String.Empty)

        ' Act
        Dim result As ViewResult = _blogController.Create(blogEntryToCreate)

        ' Assert
        Dim descriptionState = result.ViewData.ModelState("Description")
        Assert.IsTrue(TestHelpers.HasErrorMessage(descriptionState, "Description is required."))
    End Sub


    ''' <summary>
    ''' Verifies that a missing Text property generates a validation error message.
    ''' </summary>
    <TestMethod()> _
    Public Sub CreateTextRequired()
        ' Arrange 
        Dim blogEntryToCreate = BlogEntryFactory.GetWithText(String.Empty)

        ' Act
        Dim result As ViewResult = _blogController.Create(blogEntryToCreate)

        ' Assert
        Dim textState = result.ViewData.ModelState("Text")
        Assert.IsTrue(TestHelpers.HasErrorMessage(textState, "Text is required."))
    End Sub

    ''' <summary>
    ''' Verifies that a Title longer than 500 characters generates a validation error message.
    ''' </summary>
    <TestMethod()> _
    Public Sub CreateTitleMaximumLength500()
        ' Arrange
        Dim blogEntryToCreate = BlogEntryFactory.GetWithTitle("a".PadRight(501))

        ' Act
        Dim result As ViewResult = _blogController.Create(blogEntryToCreate)

        ' Assert
        Dim titleState = result.ViewData.ModelState("Title")
        Assert.IsTrue(TestHelpers.HasErrorMessage(titleState, "Title is too long."))
    End Sub

    '_______________________
    ' Business rules tests
    '_______________________


    ''' <summary>
    ''' Validates that Name property gets URL encoded correctly.
    ''' </summary>
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

    ''' <summary>
    ''' Verifies that when you don't supply a Name then the Name is created
    ''' from the Title.
    ''' </summary>
    <TestMethod()> _
    Public Sub CreateNameFromTitle()
        ' Arrange
        Dim blogEntryToCreate = BlogEntryFactory.Get()
        blogEntryToCreate.Title = "TheTitle"
        blogEntryToCreate.Name = String.Empty

        Dim archiveController = _controllerFactory.GetArchiveController()


        ' Act
        _blogController.Create(blogEntryToCreate)
        Dim result As ViewResult = archiveController.Details(2010, 12, 25, "TheTitle")

        ' Assert
        Dim blogEntry = CType(result.ViewData.Model, BlogEntry)
        Assert.AreEqual("TheTitle", blogEntry.Name)
    End Sub

    '____________________________________
    ' Paging Tests
    '____________________________________



    ''' <summary>
    ''' Verifies that the Index() action accepts a page parameter.
    ''' </summary>
    <TestMethod()> _
    Public Sub IndexAcceptsPage()
        ' Act
        Dim result As ViewResult = _blogController.Index(0)
    End Sub


    ''' <summary>
    ''' Verifies that passing a page parameter for page index 2
    ''' returns a PagedList for page index 2.
    ''' </summary>
    <TestMethod()> _
    Public Sub IndexReturnsPagedListForPage()
        ' Arrange
        TestHelpers.CreateBlogEntries(_blogController, 50)

        ' Act
        Dim result As ViewResult = _blogController.Index(2)

        ' Assert
        Dim page = CType(result.ViewData.Model, PagedList(Of BlogEntry))
        Assert.AreEqual(2, page.PageIndex)
    End Sub

    ''' <summary>
    ''' Verifies that no more than 5 entries are
    ''' returned from the Index() action
    ''' </summary>
    <TestMethod()> _
    Public Sub IndexReturnsLessThan6BlogEntries()
        ' Arrange
        TestHelpers.CreateBlogEntries(_blogController, 20)

        ' Act
        Dim result As ViewResult = _blogController.Index(0)

        ' Assert
        Dim page = CType(result.ViewData.Model, PagedList(Of BlogEntry))
        Assert.IsTrue(page.Count < 6)
    End Sub

    ''' <summary>
    ''' Verifies that blog entries are ordered by DatePublished.
    ''' </summary>
    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesInOrderOfDatePublished()
        ' Arrange
        Dim blogEntry1 = BlogEntryFactory.GetWithDatePublished(New DateTime(2005, 12, 25))
        _blogController.Create(blogEntry1)
        Dim blogEntry2 = BlogEntryFactory.GetWithDatePublished(New DateTime(2005, 12, 26))
        _blogController.Create(blogEntry2)

        ' Act
        Dim result As ViewResult = _blogController.Index(0)

        ' Assert
        Dim page = CType(result.ViewData.Model, PagedList(Of BlogEntry))
        Assert.AreEqual(blogEntry2.DatePublished, page(0).DatePublished)
    End Sub

    '____________________________
    ' Ajax Tests
    '____________________________

    ''' <summary>
    ''' Verifies that the Index_Ajax action returns a
    ''' PartialViewResult.
    ''' </summary>
    <TestMethod()> _
    Public Sub Index_AjaxReturnsPartialViewResult()
        ' Act
        Dim result = _blogController.Index_Ajax(0)

        ' Assert
        Assert.IsInstanceOfType(result, GetType(PartialViewResult))
    End Sub


End Class
