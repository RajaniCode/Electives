using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ContentManagerController : Controller
    {
 
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Download()
        {
           
            return File("~/Content/CompanyPlans.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "CompanyPlans.docx");
        }

    }
}
