using System.Linq;
using System.Web.Mvc;
using GenericRepository;
using LSMvcApplication.Models;

namespace LSMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository _repository;


        public HomeController()
        {
            _repository = new LSGenericRepository(new DataModelDataContext());
        }



        //
        // GET: /Home/

        public ActionResult Index()
        {
            var result = (from p in _repository.List<Product>()
                         where p.Price < 50.00m
                         select p).ToList();
            return View(result);

            return View(_repository.List<Product>().ToList());
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
            try
            {
                _repository.Create<Product>(productToCreate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(_repository.Get<Product>(id));
        }

        //
        // POST: /Home/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Product productToEdit)
        {
            try
            {
                _repository.Edit<Product>(productToEdit); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View(_repository.Get<Product>(id));
        }

        //
        // POST: /Home/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(Product productToDelete)
        {
            try
            {
                _repository.Delete<Product>(productToDelete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}
