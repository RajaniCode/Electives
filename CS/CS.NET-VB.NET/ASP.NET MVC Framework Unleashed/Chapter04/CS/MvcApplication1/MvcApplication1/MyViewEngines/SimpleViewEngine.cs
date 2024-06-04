using System.Web.Mvc;

namespace MvcApplication1.MyViewEngines
{
    public class SimpleViewEngine : VirtualPathProviderViewEngine
    {
        public SimpleViewEngine()
        {
            this.ViewLocationFormats = new string[] { "~/Views/{1}/{0}.simple", "~/Views/Shared/{0}.simple"};
            this.PartialViewLocationFormats = new string[] { "~/Views/{1}/{0}.simple", "~/Views/Shared/{0}.simple" };
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var physicalPath = controllerContext.HttpContext.Server.MapPath(viewPath);
            return new SimpleView(physicalPath);
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var physicalPath = controllerContext.HttpContext.Server.MapPath(partialPath);
            return new SimpleView(physicalPath);
        }
    }
}