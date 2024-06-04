using System;
using System.Web;
using System.Web.Routing;

namespace MvcApplication1.Constraints
{
    public class NotEqual:IRouteConstraint
    {
        private string _value;

        public NotEqual(string value)
        {
            _value = value;
        }
        
        public bool Match
            (
                HttpContextBase httpContext, 
                Route route, 
                string parameterName, 
                RouteValueDictionary values, 
                RouteDirection routeDirection
            )
        {
            var paramValue = values[parameterName].ToString();
            return String.Compare(paramValue, _value, true) != 0;
        }

    }
}
