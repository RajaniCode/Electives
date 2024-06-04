Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
 Public Class CommentControllerTests
    Private _controllerFactory As ControllerFactory
    Private _commentController As CommentController

    ''' <summary>
    ''' Because we use the Comment controller in every test, let's just
    ''' create one automatically.
    ''' </summary>
    <TestInitialize()> _
    Public Sub Initialize()
        _controllerFactory = New ControllerFactory()
        _commentController = _controllerFactory.GetCommentController()
    End Sub

    ''' <summary>
    ''' Verify that we can create and then get a comment.
    ''' </summary>
    <TestMethod()> _
    Public Sub CreateAndThenGetComment()
        ' Arrange
        Dim blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory)
        Dim comment1 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 1", New DateTime(2010, 12, 25))

        ' Act
        Dim archiveController = _controllerFactory.GetArchiveController()
        Dim result As ViewResult = archiveController.Details(blogEntry.DatePublished.Year, blogEntry.DatePublished.Month, blogEntry.DatePublished.Day, blogEntry.Name)

        ' Assert
        Dim comments = result.ViewData.Model.Comments
        Assert.AreEqual("Comment 1", comments(0).Title)
    End Sub

    ''' <summary>
    ''' Verify that comments are ordered by the DatePublished.
    ''' </summary>
    <TestMethod()> _
    Public Sub CommentsOrderByDatePublished()
        ' Arrange
        Dim blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory)
        Dim comment1 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 1", New DateTime(2009, 12, 25))
        Dim comment2 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 2", New DateTime(2010, 12, 25))
        Dim comment3 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 3", New DateTime(2007, 12, 25))

        ' Act
        Dim archiveController = _controllerFactory.GetArchiveController()
        Dim result As ViewResult = archiveController.Details(blogEntry.DatePublished.Year, blogEntry.DatePublished.Month, blogEntry.DatePublished.Day, blogEntry.Name)

        ' Assert
        Dim comments = result.ViewData.Model.Comments
        Assert.AreEqual("Comment 3", comments(0).Title)
        Assert.AreEqual("Comment 2", comments(2).Title)
    End Sub

    ''' <summary>
    ''' Verify that when you get a list of blog entries, each blog entry includes a comment count.
    ''' </summary>
    <TestMethod()> _
    Public Sub BlogEntriesIncludeCommentCount()
        ' Arrange
        Dim blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory)
        Dim comment1 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 1", New DateTime(2009, 12, 25))
        Dim comment2 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 2", New DateTime(2010, 12, 25))

        ' Act
        Dim blogController = _controllerFactory.GetBlogController()
        Dim result As ViewResult = blogController.Index(Nothing)

        ' Assert
        Dim entries = CType(result.ViewData.Model, List(Of BlogEntry))
        Assert.AreEqual(2, entries(0).CommentCount)
    End Sub

    '____________________
    ' Validation
    '____________________


    ''' <summary>
    ''' Verify that a missing Title generates a validation error message.
    ''' </summary>
    <TestMethod()> _
    Public Sub CommentMustHaveTitle()
        ' Arrange 
        Dim blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory)
        Dim commentToCreate = CommentFactory.GetWithTitle(blogEntry.Id, String.Empty)

        ' Act
        Dim result As ViewResult = _commentController.Create(commentToCreate)

        ' Assert
        Dim titleState = result.ViewData.ModelState("Title")
        Assert.IsTrue(TestHelpers.HasErrorMessage(titleState, "Title is required."))
    End Sub

    ''' <summary>
    ''' Verify that a missing Name (comment author) generates a validation error message.
    ''' </summary>
    <TestMethod()> _
    Public Sub CommentMustHaveName()
        ' Arrange 
        Dim blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory)
        Dim commentToCreate = CommentFactory.GetWithName(blogEntry.Id, String.Empty)

        ' Act
        Dim result As ViewResult = _commentController.Create(commentToCreate)

        ' Assert
        Dim nameState = result.ViewData.ModelState("Name")
        Assert.IsTrue(TestHelpers.HasErrorMessage(nameState, "Name is required."))
    End Sub

    ''' <summary>
    ''' Verifies that missing Text (Comment) generates a validation error message.
    ''' </summary>
    <TestMethod()> _
    Public Sub CommentMustHaveText()
        ' Arrange 
        Dim blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory)
        Dim commentToCreate = CommentFactory.GetWithText(blogEntry.Id, String.Empty)

        ' Act
        Dim result As ViewResult = _commentController.Create(commentToCreate)

        ' Assert
        Dim textState = result.ViewData.ModelState("Text")
        Assert.IsTrue(TestHelpers.HasErrorMessage(textState, "Comment is required."))
    End Sub


End Class
