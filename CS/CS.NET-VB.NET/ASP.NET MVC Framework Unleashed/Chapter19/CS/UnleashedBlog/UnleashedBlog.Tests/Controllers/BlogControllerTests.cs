using System.Collections;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Factories;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            var result = (ViewResult)_blogController.Index();

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
            var result = (ViewResult)_blogController.Index();

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
            var result = (ViewResult)_blogController.Index();

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
            var result = (ViewResult)aController.Index(null, null, null, "TheTitle");

            // Assert
            var blogEntries = (IList<BlogEntry>)result.ViewData.Model;
            Assert.AreEqual(1, blogEntries.Count);
        }








    }
}
