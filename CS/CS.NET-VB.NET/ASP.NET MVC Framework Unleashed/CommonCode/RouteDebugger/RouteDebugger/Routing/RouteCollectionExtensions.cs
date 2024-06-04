using System.Web.Routing;
using System.Web.Mvc;
using RouteDebugger.Routing;


public static class RouteCollectionExtensions
{
    public static void IgnoreRoute(this RouteCollection routes, string url)
    {
        routes.IgnoreRoute(string.Empty, url, null);
    }

    public static void IgnoreRoute(this RouteCollection routes, string name, string url)
    {
        routes.IgnoreRoute(name, url, null);
    }


    public static void IgnoreRoute(this RouteCollection routes, string name, string url, object constraints)
    {
        var newRoute = new RouteDebugger.Routing.NamedRoute(name, url, new StopRoutingHandler());
        routes.Add(name, newRoute);
    }

    public static void MapRoute(this RouteCollection routes, string name, string url)
    {
        routes.MapRoute(name, url, null, null, new MvcRouteHandler());
    }

    public static void MapRoute(this RouteCollection routes, string name, string url, object defaults)
    {
        routes.MapRoute(name, url, defaults, null, new MvcRouteHandler());
    }


    public static void MapRoute(this RouteCollection routes, string name, string url, object defaults, object constraints)
    {
        routes.MapRoute(name, url, defaults, constraints, new MvcRouteHandler());
    }

    public static void MapRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, IRouteHandler routeHandler)
    {
        var newRoute = new NamedRoute(name, url, routeHandler);
        newRoute.Defaults = new RouteValueDictionary(defaults);
        newRoute.Constraints = new RouteValueDictionary(constraints);
        routes.Add(name, newRoute);
    }
}
