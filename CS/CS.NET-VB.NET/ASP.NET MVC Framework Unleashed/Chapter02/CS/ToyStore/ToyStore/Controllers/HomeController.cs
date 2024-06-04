using System.Linq;
using System.Web.Mvc;
using ToyStore.Models;

namespace ToyStore.Controllers
{
    public class HomeController : Controller
    {
        private ToyStoreDBEntities _dataModel = new ToyStoreDBEntities(); 
               
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(_dataModel.ProductSet.ToList());
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Home/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude="Id")]Product productToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _dataModel.AddToProductSet(productToCreate);
                _dataModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
