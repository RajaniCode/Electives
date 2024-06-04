Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> Public Class BlogControllerTests

    <TestMethod()> _
    Public Sub ShowNewBlogEntries()
        ' Arrange
        Dim repository As New FakeBlogRepository()
        Dim controller = New BlogController(repository)

        ' Act
        Dim result As ViewResult = controller.Index()

        ' Assert
        CollectionAssert.AllItemsAreInstancesOfType(result.ViewData.Model, GetType(BlogEntry))
    End Sub


    <TestMethod()> _
    Public Sub CreateBlogEntry()
        ' Arrange
        Dim repository As New FakeBlogRepository()
        Dim controller = New BlogController(repository)
        Dim blogEntryToCreate = New BlogEntry()

        ' Act
        controller.Create(blogEntryToCreate)
        Dim result As ViewResult = controller.Index()

        ' Assert
        Dim firstEntry = result.ViewData.Model(0)
        Assert.AreSame(blogEntryToCreate, firstEntry)
    End Sub

End Class
