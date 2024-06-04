using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paging;
using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Factories;

namespace UnleashedBlog.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTests
    {
        private ControllerFactory _controllerFactory;
        private BlogController _blogController;

        /// <summary>
        /// Because we are testing the Blog controller, let's just create
        /// one before each test automatically.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _controllerFactory = new ControllerFactory();
            _blogController = _controllerFactory.GetBlogController();
        }

        /// <summary>
        /// Tests that the Blog controller returns a list of blog entries.
        /// </summary>
        [TestMethod]
        public void ShowNewBlogEntries()
        {
            // Act
            var result = (ViewResult)_blogController.Index(null);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(BlogEntry));
        }

        /// <summary>
        /// Verifies that you can create and then retrieve a new blog entry.
        /// </summary>
        [TestMethod]
        public void CreateBlogEntry()
        {
            // Arrange
            var blogEntryToCreate = BlogEntryFactory.GetWithName("Test");

            // Act
            _blogController.Create(blogEntryToCreate);
            var result = (ViewResult)_blogController.Index(null);

            // Assert
            var firstEntry = ((List<BlogEntry>)result.ViewData.Model)[0];
            Assert.AreEqual("Test", firstEntry.Name);
        }


        //__________________________
        // Validation Tests
        //__________________________


        /// <summary>
        /// Verifies that a missing Title property generates a validation error message.
        /// </summary>
        [TestMethod]
        public void CreateTitleRequired()
        {
            // Arrange 
            var blogEntryToCreate = BlogEntryFactory.GetWithTitle(string.Empty);

            // Act
            var result = (ViewResult)_blogController.Create(blogEntryToCreate);

            // Assert
            var titleState = result.ViewData.ModelState["Title"];
            Assert.IsTrue(TestHelpers.HasErrorMessage(titleState, "Title is required."));
        }


        /// <summary>
        /// Verifies that a missing Author property generates a validation error message.
        /// </summary>
        [TestMethod]
        public void CreateAuthorRequired()
        {
            // Arrange 
            var blogEntryToCreate = BlogEntryFactory.GetWithAuthor(string.Empty);

            // Act
            var result = (ViewResult)_blogController.Create(blogEntryToCreate);

            // Assert
            var authorState = result.ViewData.ModelState["Author"];
            Assert.IsTrue(TestHelpers.HasErrorMessage(authorState, "Author is required."));
        }

        /// <summary>
        /// Verifies that a missing Description property generates a validation error message.
        /// </summary>
        [TestMethod]
        public void CreateDescriptionRequired()
        {
            // Arrange 
            var blogEntryToCreate = BlogEntryFactory.GetWithDescription(string.Empty);

            // Act
            var result = (ViewResult)_blogController.Create(blogEntryToCreate);

            // Assert
            var descriptionState = result.ViewData.ModelState["Description"];
            Assert.IsTrue(TestHelpers.HasErrorMessage(descriptionState, "Description is required."));
        }


        /// <summary>
        /// Verifies that a missing Text property generates a validation error message.
        /// </summary>
        [TestMethod]
        public void CreateTextRequired()
        {
            // Arrange 
            var blogEntryToCreate = BlogEntryFactory.GetWithText(string.Empty);

            // Act
            var result = (ViewResult)_blogController.Create(blogEntryToCreate);

            // Assert
            var textState = result.ViewData.ModelState["Text"];
            Assert.IsTrue(TestHelpers.HasErrorMessage(textState, "Text is required."));
        }

        /// <summary>
        /// Verifies that a Title longer than 500 characters generates a validation error message.
        /// </summary>
        [TestMethod]
        public void CreateTitleMaximumLength500()
        {
            // Arrange
            var blogEntryToCreate = BlogEntryFactory.GetWithTitle("a".PadRight(501));

            // Act
            var result = (ViewResult)_blogController.Create(blogEntryToCreate);

            // Assert
            var titleState = result.ViewData.ModelState["Title"];
            Assert.IsTrue(TestHelpers.HasErrorMessage(titleState, "Title is too long."));
        }

        //_______________________
        // Business rules tests
        //_______________________


        /// <summary>
        /// Validates that Name property gets URL encoded correctly.
        /// </summary>
        [TestMethod]
        public void CreateNameIsValid()
        {
            // Arrange
            _blogController.Create( BlogEntryFactory.GetWithName("My Summer Vacation") );
            _blogController.Create( BlogEntryFactory.GetWithName("$&+,/:;=?@") );
            _blogController.Create( BlogEntryFactory.GetWithName("He said \"what?\""));

            // Act
            var result = (ViewResult)_blogController.Index(null);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            foreach (var entry in blogEntries)
            {
                StringAssert.DoesNotMatch(entry.Name, new Regex("[\"$&+,/:;=?@]"));
            }
        }

        /// <summary>
        /// Verifies that when you don't supply a Name then the Name is created
        /// from the Title.
        /// </summary>
        [TestMethod]
        public void CreateNameFromTitle()
        {
            // Arrange
            var blogEntryToCreate = BlogEntryFactory.Get();
            blogEntryToCreate.Title = "TheTitle";
            blogEntryToCreate.Name = string.Empty;

            var archiveController = _controllerFactory.GetArchiveController(); 


            // Act
            _blogController.Create(blogEntryToCreate);
            var result = (ViewResult)archiveController.Details(2010, 12, 25, "TheTitle");

            // Assert
            var blogEntry = (BlogEntry)result.ViewData.Model;
            Assert.AreEqual("TheTitle", blogEntry.Name);
        }

        //____________________________________
        // Paging Tests
        //____________________________________



        /// <summary>
        /// Verifies that the Index() action accepts a page parameter.
        /// </summary>
        [TestMethod]
        public void IndexAcceptsPage()
        {
            // Act
            var result = (ViewResult)_blogController.Index(0);
        }


        /// <summary>
        /// Verifies that passing a page parameter for page index 2
        /// returns a PagedList for page index 2.
        /// </summary>
        [TestMethod]
        public void IndexReturnsPagedListForPage()
        {
            // Arrange
            TestHelpers.CreateBlogEntries(_blogController, 50);

            // Act
            var result = (ViewResult)_blogController.Index(2);

            // Assert
            var page = (PagedList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, page.PageIndex);
        }

        /// <summary>
        /// Verifies that no more than 5 entries are
        /// returned from the Index() action
        /// </summary>
        [TestMethod]
        public void IndexReturnsLessThan6BlogEntries()
        {
            // Arrange
            TestHelpers.CreateBlogEntries(_blogController, 20);

            // Act
            var result = (ViewResult)_blogController.Index(0);

            // Assert
            var page = (PagedList<BlogEntry>)result.ViewData.Model;
            Assert.IsTrue(page.Count < 6);
        }

        /// <summary>
        /// Verifies that blog entries are ordered by DatePublished.
        /// </summary>
        [TestMethod]
        public void IndexReturnsBlogEntriesInOrderOfDatePublished()
        {
            // Arrange
            var blogEntry1 = BlogEntryFactory.GetWithDatePublished(new DateTime(2005, 12, 25));
            _blogController.Create(blogEntry1);
            var blogEntry2 = BlogEntryFactory.GetWithDatePublished(new DateTime(2005, 12, 26));
            _blogController.Create(blogEntry2);

            // Act
            var result = (ViewResult)_blogController.Index(0);

            // Assert
            var page = (PagedList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual( blogEntry2.DatePublished, page[0].DatePublished);
        }

        //____________________________
        // Ajax Tests
        //____________________________

        /// <summary>
        /// Verifies that the Index_Ajax action returns a
        /// PartialViewResult.
        /// </summary>
        [TestMethod]
        public void Index_AjaxReturnsPartialViewResult()
        {
            // Act
            var result = _blogController.Index_Ajax(0);

            // Assert
            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
        }


    }
}
