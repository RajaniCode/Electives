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

        [TestInitialize]
        public void Initialize()
        {
            _controllerFactory = new ControllerFactory();
            _archiveController = _controllerFactory.GetArchiveController();
        }


        [TestMethod]
        public void IndexReturnsBlogEntriesByYear()
        {
            // Arrange
            var bController = _controllerFactory.GetBlogController();

            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 11, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2011, 12, 26) ));

            // Act
            var result = (ViewResult)_archiveController.Index(2010, null, null, null);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, blogEntries.Count);
        }


        [TestMethod]
        public void IndexReturnsBlogEntriesByMonth()
        {
            // Arrange
            var bController = _controllerFactory.GetBlogController();

            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 11, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 26) ));

            // Act
            var result = (ViewResult)_archiveController.Index(2010, 12, null, null);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, blogEntries.Count);
        }

        [TestMethod]
        public void IndexReturnsBlogEntriesByDay()
        {
            // Arrange
            var bController = _controllerFactory.GetBlogController();

            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 25) ));
            bController.Create(BlogEntryFactory.GetWithDatePublished(new DateTime(2010, 12, 26) ));

            // Act
            var result = (ViewResult)_archiveController.Index(2010, 12, 25, null);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, blogEntries.Count);
        }

        [TestMethod]
        public void IndexReturnsBlogEntryByName()
        {
            // Arrange
            var bController = _controllerFactory.GetBlogController();
            bController.Create(BlogEntryFactory.GetWithName("Test 1"));
            bController.Create(BlogEntryFactory.GetWithName("Test 2"));

            // Act
            var result = (ViewResult)_archiveController.Index(null, null, null, "Test-2");

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(1, blogEntries.Count);
            Assert.AreEqual("Test-2", blogEntries[0].Name);
        }


    }
}
