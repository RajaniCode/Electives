using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Factories;

namespace UnleashedBlog.Tests.Controllers
{
    [TestClass]
    public class CommentControllerTests
    {
        private ControllerFactory _controllerFactory;
        private CommentController _commentController;

        /// <summary>
        /// Because we use the Comment controller in every test, let's just
        /// create one automatically.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _controllerFactory = new ControllerFactory();
            _commentController = _controllerFactory.GetCommentController();
        }

        /// <summary>
        /// Verify that we can create and then get a comment.
        /// </summary>
        [TestMethod]
        public void CreateAndThenGetComment()
        {
            // Arrange
            var blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory);
            var comment1 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 1", new DateTime(2010, 12, 25));

            // Act
            var archiveController = _controllerFactory.GetArchiveController();
            var result = (ViewResult)archiveController.Details(blogEntry.DatePublished.Year, blogEntry.DatePublished.Month, blogEntry.DatePublished.Day, blogEntry.Name); 

            // Assert
            var comments = ((BlogEntry)result.ViewData.Model).Comments;
            Assert.AreEqual("Comment 1", comments[0].Title);
        }

        /// <summary>
        /// Verify that comments are ordered by the DatePublished.
        /// </summary>
        [TestMethod]
        public void CommentsOrderByDatePublished()
        {
            // Arrange
            var blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory);
            var comment1 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 1", new DateTime(2009, 12, 25));
            var comment2 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 2", new DateTime(2010, 12, 25));
            var comment3 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 3", new DateTime(2007, 12, 25));

            // Act
            var archiveController = _controllerFactory.GetArchiveController();
            var result = (ViewResult)archiveController.Details(blogEntry.DatePublished.Year, blogEntry.DatePublished.Month, blogEntry.DatePublished.Day, blogEntry.Name);

            // Assert
            var comments = ((BlogEntry)result.ViewData.Model).Comments;
            Assert.AreEqual("Comment 3", comments[0].Title);
            Assert.AreEqual("Comment 2", comments[2].Title);
        }

        /// <summary>
        /// Verify that when you get a list of blog entries, each blog entry includes a comment count.
        /// </summary>
        [TestMethod]
        public void BlogEntriesIncludeCommentCount()
        {
            // Arrange
            var blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory);
            var comment1 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 1", new DateTime(2009, 12, 25));
            var comment2 = TestHelpers.CreateComment(_commentController, blogEntry, "Comment 2", new DateTime(2010, 12, 25));

            // Act
            var blogController = _controllerFactory.GetBlogController();
            var result = (ViewResult)blogController.Index(null);

            // Assert
            var entries = (List<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, entries[0].CommentCount);
        }

        //____________________
        // Validation
        //____________________


        /// <summary>
        /// Verify that a missing Title generates a validation error message.
        /// </summary>
        [TestMethod]
        public void CommentMustHaveTitle()
        {
            // Arrange 
            var blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory);
            var commentToCreate = CommentFactory.GetWithTitle(blogEntry.Id, string.Empty);

            // Act
            var result = (ViewResult)_commentController.Create(commentToCreate);

            // Assert
            var titleState = result.ViewData.ModelState["Title"];
            Assert.IsTrue(TestHelpers.HasErrorMessage(titleState, "Title is required."));
        }

        /// <summary>
        /// Verify that a missing Name (comment author) generates a validation error message.
        /// </summary>
        [TestMethod]
        public void CommentMustHaveName()
        {
            // Arrange 
            var blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory);
            var commentToCreate = CommentFactory.GetWithName(blogEntry.Id, string.Empty);

            // Act
            var result = (ViewResult)_commentController.Create(commentToCreate);

            // Assert
            var nameState = result.ViewData.ModelState["Name"];
            Assert.IsTrue(TestHelpers.HasErrorMessage(nameState, "Name is required."));
        }

        /// <summary>
        /// Verifies that missing Text (Comment) generates a validation error message.
        /// </summary>
        [TestMethod]
        public void CommentMustHaveText()
        {
            // Arrange 
            var blogEntry = TestHelpers.CreateBlogEntry(_controllerFactory);
            var commentToCreate = CommentFactory.GetWithText(blogEntry.Id, string.Empty);

            // Act
            var result = (ViewResult)_commentController.Create(commentToCreate);

            // Assert
            var textState = result.ViewData.ModelState["Text"];
            Assert.IsTrue(TestHelpers.HasErrorMessage(textState, "Comment is required."));
        }


    }
}
