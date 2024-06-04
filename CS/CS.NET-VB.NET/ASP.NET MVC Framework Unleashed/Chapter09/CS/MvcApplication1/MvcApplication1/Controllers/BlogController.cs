using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class BlogController : Controller
    {
        public string Archive(DateTime entryDate)
        {
            return entryDate.ToString();
        }

    }
}
