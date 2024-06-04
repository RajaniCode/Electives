using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class GuestBookController : Controller
    {
        private GuestBookDBEntities _entities = new GuestBookDBEntities();

        // GET: /GuestBook/

        public ActionResult Index()
        {
            return View(_entities.GuestSet.ToList());
        }

        // POST: /GuestBook/Create

        public ActionResult Create(Guest guestToCreate)
        {
            _entities.AddToGuestSet(guestToCreate);
            _entities.SaveChanges();

            return PartialView("Guests", _entities.GuestSet.ToList());
        }
    }
}
