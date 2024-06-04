using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HandleJsonExceptionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {            
            if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
            {   
                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        filterContext.Exception.Message,
                        filterContext.Exception.StackTrace
                    }
                };
                filterContext.ExceptionHandled = true;
            }
        }        
    }
}