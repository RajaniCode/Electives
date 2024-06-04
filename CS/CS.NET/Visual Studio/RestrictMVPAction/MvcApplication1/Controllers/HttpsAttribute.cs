using System.Security;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HttpsAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            if (!controllerContext.HttpContext.Request.IsSecureConnection)
            {
                throw new SecurityException("This action " + methodInfo.Name + " can only be called via SSL");
            }
            return true;
        }
    }
}