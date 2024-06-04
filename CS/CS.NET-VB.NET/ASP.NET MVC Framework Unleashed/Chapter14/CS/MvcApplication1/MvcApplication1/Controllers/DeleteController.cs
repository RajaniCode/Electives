using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class DeleteController : Controller
    {
        private MoviesDBEntities _entities = new MoviesDBEntities(); 

        public ActionResult Index()
        {
            return View(_entities.MovieSet.ToList());
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public ActionResult Delete(int id)
        {
            var movieToDelete = (from m in _entities.MovieSet
                                 where m.Id == id
                                 select m).FirstOrDefault();
            _entities.DeleteObject(movieToDelete);
            _entities.SaveChanges();
            return PartialView("Movies", _entities.MovieSet.ToList());
        }

        [ActionName("Delete")]
        public ActionResult Delete_GET(int id)
        {
            var movieToDelete = (from m in _entities.MovieSet
                                 where m.Id == id
                                 select m).FirstOrDefault();
            return View(movieToDelete);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ActionName("Delete")]
        public ActionResult Delete_POST(int id)
        {
            var movieToDelete = (from m in _entities.MovieSet
                                 where m.Id == id
                                 select m).FirstOrDefault();
            _entities.DeleteObject(movieToDelete);
            _entities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
