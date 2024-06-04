using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Controllers;

namespace MvcApplication1.Tests.Controllers
{
    [TestClass]
    public class JackControllerTests
    {

        [TestMethod]
        public void JackCanAccessIndex()
        {
            // Arrange
            var controller = new CompanyController();
            var indexAction = typeof(JackController).GetMethod("Index");
            var authorizeAttributes=indexAction.GetCustomAttributes(typeof(AuthorizeAttribute), true);

            // Assert
            Assert.IsTrue(authorizeAttributes.Length > 0);
            foreach (AuthorizeAttribute att in authorizeAttributes)
                Assert.AreEqual("Jack", att.Users);
        }
    }
}
