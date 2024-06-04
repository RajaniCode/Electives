using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class DownlevelController : Controller
    {
        private GuestBookDBEntities _entities = new GuestBookDBEntities();


        public ActionResult Index()
        {
            return View(_entities.GuestSet.ToList());
        }


        public ActionResult Create([Bind(Exclude = "Id")]Guest guestToCreate)
        {
            // validation
            if (guestToCreate.Name.Trim().Length == 0)
                ModelState.AddModelError("Name", "Name is required.");
            if (guestToCreate.Message.Trim().Length == 0)
                ModelState.AddModelError("Message", "Message is required.");

            if (ModelState.IsValid)
            {
                _entities.AddToGuestSet(guestToCreate);
                _entities.SaveChanges();
            }

            if (Request.IsAjaxRequest())
                return PartialView("GuestBook", _entities.GuestSet.ToList());

            return View("Index", _entities.GuestSet.ToList());
        }

    }
}
