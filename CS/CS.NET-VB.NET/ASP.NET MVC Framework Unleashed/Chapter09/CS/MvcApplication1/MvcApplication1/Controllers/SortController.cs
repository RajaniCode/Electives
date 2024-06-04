using System;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class SortController : Controller
    {

        public string Index(string values)
        {
            var brokenValues = values.Split('/');
            Array.Sort(brokenValues);
            return String.Join(", ", brokenValues);
        }


    }
}
