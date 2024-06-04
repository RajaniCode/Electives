using System.Web;
using System.Web.Routing;

namespace MvcApplication1.Constraints
{
    public class AuthenticatedConstraint : IRouteConstraint
    {

        public bool Match
            (
                HttpContextBase httpContext, 
                Route route, 
                string parameterName, 
                RouteValueDictionary values, 
                RouteDirection routeDirection
            )
        {
            return httpContext.Request.IsAuthenticated;
        }

    }
}
