using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class InvestmentController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities();

        [OutputCache(Duration=999, VaryByParam="None")]
        [Authorize]
        public ActionResult Index()
        {
            var investments = _entities.MovieSet.ToList();
            return View(investments);
        }

    }
}
