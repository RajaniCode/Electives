using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1.CutomActionFilters
{
    public class LogAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(filterContext.RouteData, "Action Executing");    
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log(filterContext.RouteData, "Action Executed");    
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log(filterContext.RouteData, "Result Executing");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log(filterContext.RouteData, "Result Executed");
        }


        private void Log(RouteData routeData, string message)
        {
            // Extract controller and action name from route data
            var controllerAndAction = String.Format("{0}.{1}", routeData.Values["controller"], routeData.Values["action"]);

            // format message
            message = String.Format("{0:T}: {1}: {2}", DateTime.Now, controllerAndAction, message);

            // write to console
            System.Diagnostics.Debug.WriteLine(message);
        }

    }
}
