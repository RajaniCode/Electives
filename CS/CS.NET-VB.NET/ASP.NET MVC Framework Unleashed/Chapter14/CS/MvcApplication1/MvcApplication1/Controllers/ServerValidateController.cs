using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ServerValidateController : Controller
    {
        private GuestBookDBEntities _entities = new GuestBookDBEntities();

        // GET: /GuestBook/

        public ActionResult Index()
        {
            return View(_entities.GuestSet.ToList());
        }

        // POST: /GuestBook/Create

        public ActionResult Create([Bind(Exclude="Id")]Guest guestToCreate)
        {
            if (guestToCreate.Name.Trim().Length == 0)
                ModelState.AddModelError("Name", "Name is required.");
            if (guestToCreate.Message.Trim().Length == 0)
                ModelState.AddModelError("Message", "Message is required.");

            if (ModelState.IsValid)
            {
                _entities.AddToGuestSet(guestToCreate);
                _entities.SaveChanges();
            }

            return PartialView("GuestBook", _entities.GuestSet.ToList());
        }
    }
}
