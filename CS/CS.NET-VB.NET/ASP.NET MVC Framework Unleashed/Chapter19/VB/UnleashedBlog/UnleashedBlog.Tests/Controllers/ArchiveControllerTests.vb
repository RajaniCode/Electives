Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
Public Class ArchiveControllerTests

    Private _controllerFactory As ControllerFactory
    Private _archiveController As ArchiveController

    <TestInitialize()> _
    Public Sub Initialize()
        _controllerFactory = New ControllerFactory()
        _archiveController = _controllerFactory.GetArchiveController()
    End Sub


    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesByYear()
        ' Arrange
        Dim bController = _controllerFactory.GetBlogController()

        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 11, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2011, 12, 26)))

        ' Act
        Dim result As ViewResult = _archiveController.Index(2010, Nothing, Nothing, Nothing)

        ' Assert
        Dim blogEntries = CType(result.ViewData.Model, IList(Of BlogEntry))
        Assert.AreEqual(2, blogEntries.Count)
    End Sub


    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesByMonth()
        ' Arrange
        Dim bController = _controllerFactory.GetBlogController()

        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 11, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 26)))

        ' Act
        Dim result As ViewResult = _archiveController.Index(2010, 12, Nothing, Nothing)

        ' Assert
        Dim blogEntries = CType(result.ViewData.Model, IList(Of BlogEntry))
        Assert.AreEqual(2, blogEntries.Count)
    End Sub

    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesByDay()
        ' Arrange
        Dim bController = _controllerFactory.GetBlogController()

        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 25)))
        bController.Create(BlogEntryFactory.GetWithDatePublished(New DateTime(2010, 12, 26)))

        ' Act
        Dim result As ViewResult = _archiveController.Index(2010, 12, 25, Nothing)

        ' Assert
        Dim blogEntries = CType(result.ViewData.Model, IList(Of BlogEntry))
        Assert.AreEqual(2, blogEntries.Count)
    End Sub

    <TestMethod()> _
    Public Sub IndexReturnsBlogEntryByName()
        ' Arrange
        Dim bController = _controllerFactory.GetBlogController()
        bController.Create(BlogEntryFactory.GetWithName("Test-1"))
        bController.Create(BlogEntryFactory.GetWithName("Test-2"))

        ' Act
        Dim result As ViewResult = _archiveController.Index(Nothing, Nothing, Nothing, "Test-2")

        ' Assert
        Dim blogEntries = CType(result.ViewData.Model, IList(Of BlogEntry))
        Assert.AreEqual(1, blogEntries.Count)
        Assert.AreEqual("Test-2", blogEntries(0).Name)
    End Sub


End Class
