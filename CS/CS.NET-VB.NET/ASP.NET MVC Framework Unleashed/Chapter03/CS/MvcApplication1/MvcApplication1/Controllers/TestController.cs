using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MvcApplication1.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Say()
        {
            return Content("Hello!");
        }

    }
}
