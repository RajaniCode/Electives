using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Controllers;

namespace MvcApplication1.Tests.Controllers
{
    [TestClass]
    public class JillControllerTests
    {

        [TestMethod]
        public void JillCanAccessIndex()
        {
            // Arrange
            var controller = new JillController();
            var principal = new FakePrincipal("Jill");

            // Act
            var result = controller.Index(principal);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        [TestMethod]
        public void JackCannotAccessIndex()
        {
            // Arrange
            var controller = new JillController();
            var principal = new FakePrincipal("Jack");

            // Act
            var result = controller.Index(principal);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpUnauthorizedResult));

        }

    
    }




}
