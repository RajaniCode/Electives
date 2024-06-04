using System.Diagnostics;
using System.Web.Mvc;


namespace MvcApplication8.Filters
{
    public class DebugTimerAttribute : ActionFilterAttribute
    {
        readonly Stopwatch _startWatch = new Stopwatch();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _startWatch.Start();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _startWatch.Stop();
            filterContext.HttpContext.Response.Write(string.Format("Controller ({0}) Action ({1}) Ellapsed Time ({2})",
                filterContext.RouteData.Values["controller"],
                filterContext.RouteData.Values["action"],
                _startWatch.ElapsedMilliseconds));
        }
    }
}
