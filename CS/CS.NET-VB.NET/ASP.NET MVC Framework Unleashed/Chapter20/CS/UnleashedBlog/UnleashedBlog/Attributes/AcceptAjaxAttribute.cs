using System;
using System.Web.Mvc;
using System.Reflection;

namespace UnleashedBlog.Attributes
{

    public sealed class AcceptAjaxAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            return controllerContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}