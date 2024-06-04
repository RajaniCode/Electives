using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using MvcFakes;
using RouteDebugger.Routing;

namespace MvcApplication1.Tests.Routes
{
    [TestClass()]
    public class RouteTest
    {
        [TestMethod]
        public void DefaultRouteMatchesHome()
        {
            // Arrange
            var routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            // Act
            var context = new FakeHttpContext("~/Home");
            var routeData = routes.GetRouteData(context);

            // Assert
            var matchedRoute = (NamedRoute)routeData.Route;
            Assert.AreEqual("Default", matchedRoute.Name);
        }


        

    [TestMethod]
    public void ProductInsertMatchesPost()
    {
        // Arrange
        var routes = new RouteCollection();
        MvcApplication.RegisterRoutes(routes);

        // Act
        var context = new FakeHttpContext("~/Product/Insert", "POST", false, null);
        var routeData = routes.GetRouteData(context);

        // Assert
        var matchedRoute = (NamedRoute)routeData.Route;
        Assert.AreEqual("ProductInsert", matchedRoute.Name);
    }




    [TestMethod] 
    public void ProductInsertDoesNotMatchGet()
    {
        // Arrange
        var routes = new RouteCollection();
        MvcApplication.RegisterRoutes(routes);

        // Act
        var context = new FakeHttpContext("~/Product/Insert", "GET", false, null);
        var routeData = routes.GetRouteData(context);

        // Assert
        if (routeData != null)
        {
            var matchedRoute = (NamedRoute)routeData.Route;
            Assert.AreNotEqual("ProductInsert", matchedRoute.Name);
        }
    }


    }
}