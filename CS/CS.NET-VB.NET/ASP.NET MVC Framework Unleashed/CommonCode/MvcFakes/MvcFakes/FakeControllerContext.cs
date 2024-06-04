using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Collections.Specialized;
using System.Web.Routing;

namespace MvcFakes
{
    public class FakeControllerContext : ControllerContext
    {
        public FakeControllerContext(NameValueCollection form, ControllerBase controller)
            :base(new FakeHttpContext(String.Empty, "GET", false, form), new RouteData(), controller) {}

        public FakeControllerContext(string userName, RouteData routeData, ControllerBase controller)
            : base(new FakeHttpContext(String.Empty, userName), routeData, controller) { }

    
    }
}
