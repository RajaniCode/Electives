using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Controllers;
using MvcApplication1.Models;
using MvcApplication1.Tests.Fakes;
using MvcFakes;

namespace MvcApplication1.Tests.Controllers
{
    [TestClass]
    public class SimpleMovieControllerTests
    {

        [TestMethod]
        public void IndexAddsMoviesToCache()
        {
            // Arrange
            var cache = new FakeCache();
            var service = new SimpleMovieService(new FakeSimpleMovieRepository(), cache); 
            var controller = new SimpleMovieController(service);

            // Act
            controller.Index();

            // Assert
            Assert.IsInstanceOfType(cache["movies"], typeof(IEnumerable<Movie>));
        }


        [TestMethod]
        public void IndexRetrievesMovieFromCache()
        {
            // Arrange movies
            var movies = new List<Movie>();
            movies.Add(Movie.CreateMovie(1, "Star Wars", "Lucas", DateTime.Parse("1/1/1977")));

            // Arrange cache
            var cache = new FakeCache();
            cache["movies"] = movies;
            
            // Arrange controller
            var service = new SimpleMovieService(new FakeSimpleMovieRepository(), cache);
            var controller = new SimpleMovieController(service);

            // Act
            var results = (ViewResult)controller.Index();

            // Assert
            var movieResults = (List<Movie>)results.ViewData.Model;
            CollectionAssert.AreEqual(movies, movieResults);
        }



    }
}
