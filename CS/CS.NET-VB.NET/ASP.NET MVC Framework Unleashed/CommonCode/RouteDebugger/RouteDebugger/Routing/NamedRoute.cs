using System.Web.Routing;

namespace RouteDebugger.Routing
{
    public class NamedRoute : Route
    {
        private string _name;

        public NamedRoute(string name, string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
            _name = name;
        }

        public NamedRoute(string name, string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
            _name = name;
        }

        public NamedRoute(string name, string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

    }


}
