using System;
using System.Web.Mvc;
using System.Reflection;
public sealed class AcceptAjaxAttribute : ActionMethodSelectorAttribute
{
    // Methods
    public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
    {
        if (controllerContext == null)
        {
            throw new ArgumentNullException("controllerContext");
        }
        return controllerContext.HttpContext.Request.IsAjaxRequest();
    }
}
