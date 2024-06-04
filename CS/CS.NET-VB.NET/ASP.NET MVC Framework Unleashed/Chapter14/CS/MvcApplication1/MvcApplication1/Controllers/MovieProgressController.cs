using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcApplication1.Models;
using System.Threading;

namespace MvcApplication1.Controllers
{
    public class MovieProgressController : Controller
    {

        private MoviesDBEntities _entities = new MoviesDBEntities();

        // GET: /Movie/

        public ActionResult Index()
        {
            return View(_entities.MovieSet.ToList());
        }

        // GET: /Movie/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: /Movie/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public string Create(Movie movieToCreate)
        {
            Thread.Sleep(5 * 1000);
            try
            {
                _entities.AddToMovieSet(movieToCreate);
                _entities.SaveChanges();
                return "Inserted new movie " + movieToCreate.Title;
            }
            catch
            {
                return "Could not insert movie " + movieToCreate.Title;
            }
        }


    }
}
