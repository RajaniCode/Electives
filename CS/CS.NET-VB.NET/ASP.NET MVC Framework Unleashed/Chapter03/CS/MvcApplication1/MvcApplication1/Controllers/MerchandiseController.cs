using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class MerchandiseController : Controller
    {
        private MerchandiseRepository _repository = new MerchandiseRepository();

        // GET: /Merchandise/Edit
        [ActionName("Edit")]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit_GET(Merchandise merchandiseToEdit)
        {
            return View(merchandiseToEdit);
        }

        // POST: /Merchandise/Edit
        [ActionName("Edit")]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit_POST(Merchandise merchandiseToEdit)
        {
            try
            {
                _repository.Edit(merchandiseToEdit);
                return RedirectToAction("Edit");
            }
            catch
            {
                return View();
            }
        }
    }
}
