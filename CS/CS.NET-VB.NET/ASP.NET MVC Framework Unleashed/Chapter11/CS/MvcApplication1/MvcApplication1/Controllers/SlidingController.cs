using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Caching;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class SlidingController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities(); 

        public ActionResult Details(int id)
        {
            var cache = this.HttpContext.Cache;
            var key = GetMovieCacheKey(id);
            var movie = (Movie)cache[key];


            if (movie != null)
            {
                Debug.WriteLine("Got movie from cache");
            }
            else
            {
                Debug.WriteLine("Getting movie from database");
                movie = (from m in _entities.MovieSet
                         where m.Id == id
                         select m).FirstOrDefault();
                cache.Insert(key, movie, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10));
            }

            return View(movie);
        }


        private string GetMovieCacheKey(int movieId)
        {
            return "movie" + movieId.ToString();
        }
    }
}
