using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Controllers;
using MvcApplication1.Models;
using MvcApplication1.Tests.Models;

namespace MvcApplication1.Tests.Controllers
{
    [TestClass]
    public class Movie2ControllerTests
    {

        [TestMethod]
        public void DirectorRequired()
        {
            // Arrange
            var modelState = new ModelStateDictionary();
            var service = new MovieService(modelState, new FakeMovieRepository());
            var controller = new Movie2Controller(service);
            var movieToCreate = Movie.CreateMovie(0, "Star Wars", String.Empty, DateTime.Parse("1/1/1977"));

            // Act
            controller.Create(movieToCreate);

            // Assert
            Assert.IsTrue(HasErrorMessage(modelState["Director"], "Director is required."));        
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


    }
}
