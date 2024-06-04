using System;
using System.Reflection;
using System.Web.Mvc;

namespace UnleashedBlog.Attributes
{
    /// <summary>
    /// Allows an action to be called only within the context of an Ajax request. This
    /// code is from the Microsoft ASP.NET MVC futures.
    /// </summary>
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