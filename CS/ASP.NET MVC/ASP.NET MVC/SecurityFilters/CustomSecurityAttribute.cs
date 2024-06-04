using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityFilters
{
    public class CustomSecurityAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {           
            //Add code that authorize user access
            return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            base.HandleUnauthorizedRequest(context);
        }
    }
}