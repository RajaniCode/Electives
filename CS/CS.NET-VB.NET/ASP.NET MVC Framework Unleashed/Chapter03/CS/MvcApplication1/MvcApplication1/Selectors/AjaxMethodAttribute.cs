using System.Reflection;
using System.Web.Mvc;

namespace MvcApplication1.Selectors
{
    public class AjaxMethod : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}
