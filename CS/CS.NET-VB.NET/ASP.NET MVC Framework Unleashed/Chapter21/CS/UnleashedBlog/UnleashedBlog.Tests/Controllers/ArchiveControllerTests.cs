using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Models;
using UnleashedBlog.Tests.Factories;

namespace UnleashedBlog.Tests.Controllers
{
    [TestClass]
    public class ArchiveControllerTests
    {
        private ControllerFactory _controllerFactory;
        private ArchiveController _archiveController;


        /// <summary>
        /// Because we use the Archive controller in every test, let's just create
        /// one automatically.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _controllerFactory = new ControllerFactory();
            _archiveController = _controllerFactory.GetArchiveController();
        }


        /// <summary>
        /// Verifies that Index() action returns blog entries that match a specific year.
        /// </summary>
        [TestMethod]
        public void IndexReturnsBlogEntriesByYear()
        {
            // Arrange
            var bController = _controllerFactory.GetBlogController();

            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 11, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2011, 12, 26) ));

            // Act
            var result = (ViewResult)_archiveController.Index(null, 2010, null, null);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, blogEntries.Count);
        }

        /// <summary>
        /// Verifies that Index() action returns blog entries that match a specific month.
        /// </summary>
        [TestMethod]
        public void IndexReturnsBlogEntriesByMonth()
        {
            // Arrange
            var bController = _controllerFactory.GetBlogController();

            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 11, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 26) ));

            // Act
            var result = (ViewResult)_archiveController.Index(null, 2010, 12, null);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, blogEntries.Count);
        }

        /// <summary>
        /// Verifies that Index() action returns blog entries that match a specific day.
        /// </summary>
        [TestMethod]
        public void IndexReturnsBlogEntriesByDay()
        {
            // Arrange
            var bController = _controllerFactory.GetBlogController();

            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 26) ));

            // Act
            var result = (ViewResult)_archiveController.Index(null, 2010, 12, 25);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, blogEntries.Count);
        }

        /// <summary>
        /// Verifies that Index() action returns blog entries that match a specific name.
        /// </summary>
        [TestMethod]
        public void IndexReturnsBlogEntryByName()
        {
            // Arrange
            var bController = _controllerFactory.GetBlogController();
            bController.Create(BlogEntryFactory.GetWithName("Test 1"));
            bController.Create(BlogEntryFactory.GetWithName("Test 2"));

            // Act
            var result = (ViewResult)_archiveController.Details(2010, 12, 25, "Test-2");

            // Assert
            var blogEntry = (BlogEntry)result.ViewData.Model;
            Assert.AreEqual("Test-2", blogEntry.Name);
        }

        //____________________
        // Ajax Tests
        //____________________

        /// <summary>
        /// Verifies that Index() action returns a PartialViewResult.
        /// </summary>
        [TestMethod]
        public void Index_AjaxReturnsPartialViewResult()
        {
            // Act
            var result = _archiveController.Index_Ajax(0, 2010, 12, 25);

            // Assert
            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
        }


    }
}
