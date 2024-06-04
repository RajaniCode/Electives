using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Models;

namespace UnleashedBlog.Tests.Controllers
{
    [TestClass]
    public class ArchiveControllerTests
    {

        [TestMethod]
        public void IndexReturnsBlogEntriesByYear()
        {
            // Arrange
            var repository = new FakeBlogRepository();
            var blogController = new BlogController(repository);
            var archiveController = new ArchiveController(repository);


            blogController.Create(new BlogEntry { Name = "Test-1", DatePublished = new DateTime(2010, 11, 25) });
            blogController.Create(new BlogEntry { Name = "Test-2", DatePublished = new DateTime(2010, 12, 25) });
            blogController.Create(new BlogEntry { Name = "Test-3", DatePublished = new DateTime(2011, 12, 26) });

            // Act
            var result = (ViewResult)archiveController.Index(2010, null, null, null);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, blogEntries.Count);
        }


        [TestMethod]
        public void IndexReturnsBlogEntriesByMonth()
        {
            // Arrange
            var repository = new FakeBlogRepository();
            var blogController = new BlogController(repository);
            var archiveController = new ArchiveController(repository);


            blogController.Create(new BlogEntry { Name = "Test-1", DatePublished = new DateTime(2010, 11, 25) });
            blogController.Create(new BlogEntry { Name = "Test-2", DatePublished = new DateTime(2010, 12, 25) });
            blogController.Create(new BlogEntry { Name = "Test-3", DatePublished = new DateTime(2010, 12, 26) });

            // Act
            var result = (ViewResult)archiveController.Index(2010, 12, null, null);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, blogEntries.Count);
        }

        [TestMethod]
        public void IndexReturnsBlogEntriesByDay()
        {
            // Arrange
            var repository = new FakeBlogRepository();
            var blogController = new BlogController(repository);
            var archiveController = new ArchiveController(repository);


            blogController.Create(new BlogEntry { Name = "Test-1", DatePublished = new DateTime(2010, 12, 25) });
            blogController.Create(new BlogEntry { Name = "Test-2", DatePublished = new DateTime(2010, 12, 25) });
            blogController.Create(new BlogEntry { Name = "Test-3", DatePublished = new DateTime(2010, 12, 26) });

            // Act
            var result = (ViewResult)archiveController.Index(2010, 12, 25, null);

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, blogEntries.Count);
        }


        [TestMethod]
        public void IndexReturnsBlogEntryByName()
        {
            // Arrange
            var repository = new FakeBlogRepository();
            var blogController = new BlogController(repository);
            var archiveController = new ArchiveController(repository);

            blogController.Create(new BlogEntry { Name = "Test-1", DatePublished = new DateTime(2010, 12, 25) });
            blogController.Create(new BlogEntry { Name = "Test-2", DatePublished = new DateTime(2010, 12, 25) });

            // Act
            var result = (ViewResult)archiveController.Index(null, null, null, "Test-2");

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(1, blogEntries.Count);
            Assert.AreEqual("Test-2", blogEntries[0].Name);
        }


    }
}
