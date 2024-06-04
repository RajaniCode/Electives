Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
    Public Class ArchiveControllerTests

    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesByYear()
        ' Arrange
        Dim repository = New FakeBlogRepository()
        Dim blogController = New BlogController(repository)
        Dim archiveController = New ArchiveController(repository)


        blogController.Create(New BlogEntry With {.Name = "Test-1", .DatePublished = New DateTime(2010, 11, 25)})
        blogController.Create(New BlogEntry With {.Name = "Test-2", .DatePublished = New DateTime(2010, 12, 25)})
        blogController.Create(New BlogEntry With {.Name = "Test-3", .DatePublished = New DateTime(2011, 12, 26)})

        ' Act
        Dim result As ViewResult = archiveController.Index(2010, Nothing, Nothing, Nothing)

        ' Assert
        Dim blogEntries As IList(Of BlogEntry) = result.ViewData.Model
        Assert.AreEqual(2, blogEntries.Count)
    End Sub


    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesByMonth()
        ' Arrange
        Dim repository = New FakeBlogRepository()
        Dim blogController = New BlogController(repository)
        Dim archiveController = New ArchiveController(repository)


        blogController.Create(New BlogEntry With {.Name = "Test-1", .DatePublished = New DateTime(2010, 11, 25)})
        blogController.Create(New BlogEntry With {.Name = "Test-2", .DatePublished = New DateTime(2010, 12, 25)})
        blogController.Create(New BlogEntry With {.Name = "Test-3", .DatePublished = New DateTime(2010, 12, 26)})

        ' Act
        Dim result As ViewResult = archiveController.Index(2010, 12, Nothing, Nothing)

        ' Assert
        Dim blogEntries As IList(Of BlogEntry) = result.ViewData.Model
        Assert.AreEqual(2, blogEntries.Count)
    End Sub

    <TestMethod()> _
    Public Sub IndexReturnsBlogEntriesByDay()
        ' Arrange
        Dim repository = New FakeBlogRepository()
        Dim blogController = New BlogController(repository)
        Dim archiveController = New ArchiveController(repository)


        blogController.Create(New BlogEntry With {.Name = "Test-1", .DatePublished = New DateTime(2010, 12, 25)})
        blogController.Create(New BlogEntry With {.Name = "Test-2", .DatePublished = New DateTime(2010, 12, 25)})
        blogController.Create(New BlogEntry With {.Name = "Test-3", .DatePublished = New DateTime(2010, 12, 26)})

        ' Act
        Dim result As ViewResult = archiveController.Index(2010, 12, 25, Nothing)

        ' Assert
        Dim blogEntries As IList(Of BlogEntry) = result.ViewData.Model
        Assert.AreEqual(2, blogEntries.Count)
    End Sub

    <TestMethod()> _
    Public Sub IndexReturnsBlogEntryByName()
        ' Arrange
        Dim repository = New FakeBlogRepository()
        Dim blogController = New BlogController(repository)
        Dim archiveController = New ArchiveController(repository)

        blogController.Create(New BlogEntry With {.Name = "Test-1", .DatePublished = New DateTime(2010, 12, 25)})
        blogController.Create(New BlogEntry With {.Name = "Test-2", .DatePublished = New DateTime(2010, 12, 25)})

        ' Act
        Dim result As ViewResult = archiveController.Index(2010, 12, 25, "Test-1")

        ' Assert
        Dim blogEntries As IList(Of BlogEntry) = result.ViewData.Model
        Assert.AreEqual(1, blogEntries.Count)
        Assert.AreEqual("Test-1", blogEntries(0).Name)
    End Sub


End Class
