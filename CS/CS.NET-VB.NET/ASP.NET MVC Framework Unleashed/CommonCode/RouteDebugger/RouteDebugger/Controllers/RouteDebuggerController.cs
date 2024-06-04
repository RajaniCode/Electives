using System.Web.Mvc;
using RouteDebugger.Views.RouteDebugger;
using MvcFakes;

namespace RouteDebugger.Controllers
{
    public class RouteDebuggerController:Controller
    {

        public ActionResult Index(string url, string httpVerb)
        {
            var context = new FakeHttpContext(MakeAppRelative(url), httpVerb);
            var debuggerView = new DebuggerView(url, httpVerb, context);
            return Content(debuggerView.ExecuteResult(), "text/html");
        }



        private string MakeAppRelative(string url)
        {
            url = url ?? "~/";

            if (!url.StartsWith("~"))
            {
                if (!url.StartsWith("/"))
                    url = "~/" + url;
                else
                    url = "~" + url;
            }
            return url;
        }



    }
}
