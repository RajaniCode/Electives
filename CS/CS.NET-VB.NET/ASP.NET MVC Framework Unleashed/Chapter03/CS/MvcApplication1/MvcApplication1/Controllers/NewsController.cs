using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcApplication1.Selectors;

namespace MvcApplication1.Controllers
{
    public class NewsController : Controller
    {
        private readonly List<string> _news = new List<string>();
        private Random _rnd = new Random();

        public NewsController()
        {
            _news.Add("Moon explodes!");
            _news.Add("Stock market up 200 percent!");
            _news.Add("Talking robot created!");
        }

        public ActionResult Index()
        {
            var selectedIndex = _rnd.Next(_news.Count);
            ViewData.Model = _news[selectedIndex];
            return View();
        }


        [AjaxMethod]
        [ActionName("Index")]
        public string Index_AJAX()
        {
            var selectedIndex = _rnd.Next(_news.Count);
            return _news[selectedIndex];
        }


    }
}
