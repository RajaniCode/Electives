using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Controllers;

namespace MvcApplication1.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();
 
            // Act
            var result = controller.Index();

            // Did we get a view result?
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            // Did we get a view named Index?
            var indexResult = (ViewResult)result;
            Assert.AreEqual("Index", indexResult.ViewName);

            // Did we get message in view data?
            Assert.AreEqual("Hello World!", indexResult.ViewData["message"]);
        }

    }
}
