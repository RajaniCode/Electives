using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ContentController : Controller
    {
        // GET: /Content/Create
        public ActionResult Create()
        {
            return View();
        } 

        // POST: /Content/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(HttpPostedFileBase upload)
        {
            // Save file
            var fileName = Path.GetFileName(upload.FileName);
            upload.SaveAs(Server.MapPath("~/Uploads/" + fileName));

            return RedirectToAction("Create");
        }
    }
}
