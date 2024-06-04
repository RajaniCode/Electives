using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Controllers;

namespace MvcApplication1.Tests.Controllers
{
    [TestClass]
    public class SimpleControllerTests
    {

        [TestMethod]
        public void TimeIsCached()
        {
            // Arrange
            var timeMethod = typeof(SimpleController).GetMethod("Time");
            var outputCacheAttributes = timeMethod.GetCustomAttributes(typeof(OutputCacheAttribute), true);

            // Assert
            Assert.IsTrue(outputCacheAttributes.Length > 0);
            foreach (OutputCacheAttribute att in outputCacheAttributes)
                Assert.AreEqual(5, att.Duration);
        }

    }
}
