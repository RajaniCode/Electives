using System.Collections;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Factories;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Paging;
using System;

namespace UnleashedBlog.Tests.Controllers
{
    [TestClass]
    public class BlogControllerTests
    {
        private ControllerFactory _controllerFactory;
        private BlogController _blogController;

        [TestInitialize]
        public void Initialize()
        {
            _controllerFactory = new ControllerFactory();
            _blogController = _controllerFactory.GetBlogController();
        }


        [TestMethod]
        public void ShowNewBlogEntries()
        {
            // Act
            var result = (ViewResult)_blogController.Index(null);

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(BlogEntry));
        }


        [TestMethod]
        public void CreateBlogEntry()
        {
            // Arrange
            var blogEntryToCreate = BlogEntryFactory.Get();

            // Act
            _blogController.Create(blogEntryToCreate);
            var result = (ViewResult)_blogController.Index(null);

            // Assert
            var firstEntry = ((IList)result.ViewData.Model)[0];
            Assert.AreSame(blogEntryToCreate, firstEntry);
        }



        private bool HasErrorMessage(ModelState modelState, string errorMessage)
        {
            foreach (var error in modelState.Errors)
            {
                if (error.ErrorMessage == errorMessage)
                    return true;
            }
            return false;
        }




        [TestMethod]
        public void CreateTextRequired()
        {
            // Arrange 
            var blogEntryToCreate = BlogEntryFactory.GetWithText(string.Empty);

            // Act
            var result = (ViewResult)_blogController.Create(blogEntryToCreate);

            // Assert
            var titleState = result.ViewData.ModelState["Text"];
            Assert.IsTrue(HasErrorMessage(titleState, "Text is required."));
        }





        [TestMethod]
        public void CreateTitleRequired()
        {
            // Arrange 
            var blogEntryToCreate = BlogEntryFactory.GetWithTitle(string.Empty);

            // Act
            var result = (ViewResult)_blogController.Create(blogEntryToCreate);

            // Assert
            var titleState = result.ViewData.ModelState["Title"];
            Assert.IsTrue(HasErrorMessage(titleState, "Title is required."));
        }


        [TestMethod]
        public void CreateTitleMaximumLength500()
        {
            // Arrange
            var blogEntryToCreate = BlogEntryFactory.GetWithTitle("a".PadRight(501));

            // Act
            var result = (ViewResult)_blogController.Create(blogEntryToCreate);

            // Assert
            var titleState = result.ViewData.ModelState["Title"];
            Assert.IsTrue(HasErrorMessage(titleState, "Title is too long."));
        }



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


        [TestMethod]
        public void CreateNameFromTitle()
        {
            // Arrange
            var blogEntryToCreate = BlogEntryFactory.Get();
            blogEntryToCreate.Title = "TheTitle";
            blogEntryToCreate.Name = string.Empty;

            var aController = _controllerFactory.GetArchiveController(); 


            // Act
            _blogController.Create(blogEntryToCreate);
            var result = (ViewResult)aController.Index(null, null, null, null, "TheTitle");

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(1, blogEntries.Count);
        }


        // Paging Tests


        [TestMethod]
        public void IndexAcceptsPage()
        {
            // Act
            var result = (ViewResult)_blogController.Index(0);
        }


        [TestMethod]
        public void IndexReturnsPagedListForPage()
        {
            // Arrange
            CreateBlogEntries(50);

            // Act
            var result = (ViewResult)_blogController.Index(2);

            // Assert
            var page = (PagedList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(2, page.PageIndex);
        }


        [TestMethod]
        public void IndexReturnsLessThan6BlogEntries()
        {
            // Arrange
            CreateBlogEntries(20);

            // Act
            var result = (ViewResult)_blogController.Index(0);

            // Assert
            var page = (PagedList<BlogEntry>)result.ViewData.Model;
            Assert.IsTrue(page.Count < 6);
        }


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
            Assert.AreSame( blogEntry2, page[0]);
        }


        private void CreateBlogEntries(int count)
        {
            for (int i=0;i<count;i++)
            {
                var name = "Blog Entry " + i.ToString();
                var blogEntryToCreate = BlogEntryFactory.GetWithName(name);
                _blogController.Create(blogEntryToCreate);
            }
        }


        // Ajax Tests
   
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
