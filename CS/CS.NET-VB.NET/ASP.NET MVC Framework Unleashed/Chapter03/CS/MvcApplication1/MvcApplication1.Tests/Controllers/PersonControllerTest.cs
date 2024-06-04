using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Controllers;

namespace MvcApplication1.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTest
    {
        [TestMethod]
        public void DetailsWithId()
        {
            // Arrange
            var controller = new PersonController();

            // Act
            var result = (ViewResult)controller.Details(33);

            // Assert
            Assert.AreEqual("Details", result.ViewName);
        }


        [TestMethod]
        public void DetailsWithoutId()
        {
            // Arrange
            var controller = new PersonController();

            // Act
            var result = (RedirectToRouteResult)controller.Details(null);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
