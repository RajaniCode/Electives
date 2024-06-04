using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository;

        public ProductController()
            : this(new ProductRepository()) { }

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }


        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(_repository.List());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            return View(_repository.Get(id));
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Product productToCreate)
        {
            try
            {
                _repository.Create(productToCreate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }

        //
        // POST: /Product/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Product productToEdit)
        {
            try
            {
                _repository.Edit(productToEdit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id)
        {
            return View(_repository.Get(id));
        }

        //
        // POST: /Product/Delete

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(Product productToDelete)
        {
            try
            {
                _repository.Delete(productToDelete);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
