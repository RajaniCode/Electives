Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
 Public Class ArchiveControllerTests
    Private _controllerFactory As ControllerFactory
    Private _archiveController As ArchiveController


    ''' <summary>
    ''' Because we use the Archive controller in every test, let's just create
    ''' one automatically.
    ''' </summary>
    <TestInitialize()> _
    Public Sub Initialize()
        _controllerFactory = New ControllerFactory()
        _archiveController = _controllerFactory.GetArchiveController()
    End Sub


    ''' <summary>
    ''' Verifies that Index() action returns blog entries that match a specific year.
    ''' </summary>
    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesByYear()
        ' Arrange
        Dim bController = _controllerFactory.GetBlogController()

        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 11, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2011, 12, 26)))

        ' Act
        Dim result = CType(_archiveController.Index(Nothing, 2010, Nothing, Nothing), ViewResult)

        ' Assert
        Dim blogEntries = CType(result.ViewData.Model, IList(Of BlogEntry))
        Assert.AreEqual(2, blogEntries.Count)
    End Sub

    ''' <summary>
    ''' Verifies that Index() action returns blog entries that match a specific month.
    ''' </summary>
    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesByMonth()
        ' Arrange
        Dim bController = _controllerFactory.GetBlogController()

        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 11, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 26)))

        ' Act
        Dim result = CType(_archiveController.Index(Nothing, 2010, 12, Nothing), ViewResult)

        ' Assert
        Dim blogEntries = CType(result.ViewData.Model, IList(Of BlogEntry))
        Assert.AreEqual(2, blogEntries.Count)
    End Sub

    ''' <summary>
    ''' Verifies that Index() action returns blog entries that match a specific day.
    ''' </summary>
    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesByDay()
        ' Arrange
        Dim bController = _controllerFactory.GetBlogController()

        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 26)))

        ' Act
        Dim result = CType(_archiveController.Index(Nothing, 2010, 12, 25), ViewResult)

        ' Assert
        Dim blogEntries = CType(result.ViewData.Model, IList(Of BlogEntry))
        Assert.AreEqual(2, blogEntries.Count)
    End Sub

    ''' <summary>
    ''' Verifies that Index() action returns blog entries that match a specific name.
    ''' </summary>
    <TestMethod()> _
    Public Sub IndexReturnsBlogEntryByName()
        ' Arrange
        Dim bController = _controllerFactory.GetBlogController()
        bController.Create(BlogEntryFactory.GetWithName("Test-1"))
        bController.Create(BlogEntryFactory.GetWithName("Test-2"))

        ' Act
        Dim result = CType(_archiveController.Details(2010, 12, 25, "Test-2"), ViewResult)

        ' Assert
        Dim blogEntry = CType(result.ViewData.Model, BlogEntry)
        Assert.AreEqual("Test-2", blogEntry.Name)
    End Sub

    '____________________
    ' Ajax Tests
    '____________________

    ''' <summary>
    ''' Verifies that Index() action returns a PartialViewResult.
    ''' </summary>
    <TestMethod()> _
    Public Sub Index_AjaxReturnsPartialViewResult()
        ' Act
        Dim result = _archiveController.Index_Ajax(0, 2010, 12, 25)

        ' Assert
        Assert.IsInstanceOfType(result, GetType(PartialViewResult))
    End Sub


End Class
