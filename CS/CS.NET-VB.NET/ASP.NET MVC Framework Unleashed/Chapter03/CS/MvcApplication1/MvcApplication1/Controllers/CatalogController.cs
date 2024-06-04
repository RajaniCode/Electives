using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CatalogController : Controller
    {
       
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }


        protected override void HandleUnknownAction(string actionName)
        {
            ViewData["actionName"] = actionName;
            View("Unknown").ExecuteResult(this.ControllerContext);
        }


    }
}
