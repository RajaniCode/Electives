using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class SlideController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities();

        public ActionResult Index()
        {
            return View(_entities.MovieSet.ToList());
        }


        public ActionResult Refresh()
        {
            return PartialView("Movies", _entities.MovieSet.ToList());
        }

    }
}
