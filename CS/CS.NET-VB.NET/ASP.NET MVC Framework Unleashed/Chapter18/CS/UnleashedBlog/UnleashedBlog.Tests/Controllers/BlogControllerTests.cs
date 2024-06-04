using System.Collections;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Models;

namespace UnleashedBlog.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTests
    {

        [TestMethod]
        public void ShowNewBlogEntries()
        {
            // Arrange
            var repository = new FakeBlogRepository();
            var controller = new BlogController(repository);

            // Act
            var result = (ViewResult)controller.Index();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(BlogEntry));
        }


        [TestMethod]
        public void CreateBlogEntry()
        {
            // Arrange
            var repository = new FakeBlogRepository();
            var controller = new BlogController(repository);
            var blogEntryToCreate = new BlogEntry();

            // Act
            controller.Create(blogEntryToCreate);
            var result = (ViewResult)controller.Index();

            // Assert
            var firstEntry = ((IList)result.ViewData.Model)[0];
            Assert.AreSame(blogEntryToCreate, firstEntry);
        }



    }
}
