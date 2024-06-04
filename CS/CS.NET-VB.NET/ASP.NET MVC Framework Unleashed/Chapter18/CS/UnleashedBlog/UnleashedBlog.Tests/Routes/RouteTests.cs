using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcFakes;
using RouteDebugger.Routing;

namespace UnleashedBlog.Tests.Routes
{
    [TestClass]
    public class RouteTests
    {

        [TestMethod]
        public void DefaultRoute()
        {
            // Arrange
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            // Act
            var context = new FakeHttpContext("~/");
            var routeData = routes.GetRouteData(context);

            // Assert
            var matchedRoute = (NamedRoute)routeData.Route;
            Assert.AreEqual("Default", matchedRoute.Name);
        }


        [TestMethod]
        public void ArchiveYear()
        {
            // Arrange
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            // Act
            var context = new FakeHttpContext("~/Archive/2008");
            var routeData = routes.GetRouteData(context);

            // Assert
            var matchedRoute = (NamedRoute)routeData.Route;
            Assert.AreEqual("ArchiveYear", matchedRoute.Name);
            Assert.AreEqual("2008", routeData.Values["year"]);
        }


        [TestMethod]
        public void ArchiveYearMonth()
        {
            // Arrange
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            // Act
            var context = new FakeHttpContext("~/Archive/2008/12");
            var routeData = routes.GetRouteData(context);

            // Assert
            var matchedRoute = (NamedRoute)routeData.Route;
            Assert.AreEqual("ArchiveYearMonth", matchedRoute.Name);
            Assert.AreEqual("2008", routeData.Values["year"]);
            Assert.AreEqual("12", routeData.Values["month"]);
        }

        [TestMethod]
        public void ArchiveYearMonthDay()
        {
            // Arrange
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            // Act
            var context = new FakeHttpContext("~/Archive/2008/12/25");
            var routeData = routes.GetRouteData(context);

            // Assert
            var matchedRoute = (NamedRoute)routeData.Route;
            Assert.AreEqual("ArchiveYearMonthDay", matchedRoute.Name);
            Assert.AreEqual("2008", routeData.Values["year"]);
            Assert.AreEqual("12", routeData.Values["month"]);
            Assert.AreEqual("25", routeData.Values["day"]);
        }


        [TestMethod]
        public void ArchiveYearMonthDayName()
        {
            // Arrange
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            // Act
            var context = new FakeHttpContext("~/Archive/2008/12/25/Test");
            var routeData = routes.GetRouteData(context);

            // Assert
            var matchedRoute = (NamedRoute)routeData.Route;
            Assert.AreEqual("ArchiveFull", matchedRoute.Name);
            Assert.AreEqual("2008", routeData.Values["year"]);
            Assert.AreEqual("12", routeData.Values["month"]);
            Assert.AreEqual("25", routeData.Values["day"]);
            Assert.AreEqual("Test", routeData.Values["name"]);
        }



    }
}
