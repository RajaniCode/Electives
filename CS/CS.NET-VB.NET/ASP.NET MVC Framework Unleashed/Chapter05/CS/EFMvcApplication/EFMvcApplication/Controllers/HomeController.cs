using System.Linq;
using System.Web.Mvc;
using EFMvcApplication.Models;
using GenericRepository;

namespace EFMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository _repository;

        public HomeController()
            :this(new EFGenericRepository(new ToyStoreDBEntities())){}
        
        public HomeController(IGenericRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
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
            if (productToCreate.Name.Trim().Length == 0)
            {
                ModelState.AddModelError("Name", "Product name is required.");
                return View();
            }
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
            _repository.Delete<Product>(productToDelete);
            return RedirectToAction("Index");
        }

    
    }
}
