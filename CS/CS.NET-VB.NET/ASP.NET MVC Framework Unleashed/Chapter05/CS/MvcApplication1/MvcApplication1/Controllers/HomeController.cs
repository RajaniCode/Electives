using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ProductsDBEntities _entities = new ProductsDBEntities();


        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(_entities.ProductSet.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            var result = (from p in _entities.ProductSet 
                          where p.Id == id 
                          select p).FirstOrDefault();
            return View(result);
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
        public ActionResult Create(Product productToCreate)
        {
            try
            {
                _entities.AddToProductSet(productToCreate);
                _entities.SaveChanges();

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
            var productToEdit = (from p in _entities.ProductSet
                          where p.Id == id
                          select p).FirstOrDefault();
            return View(productToEdit);
        }

        //
        // POST: /Home/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Product productToEdit)
        {
            try
            {
                var originalProduct = (from p in _entities.ProductSet
                                     where p.Id == productToEdit.Id
                                     select p).FirstOrDefault();
                _entities.ApplyPropertyChanges(originalProduct.EntityKey.EntitySetName, productToEdit);
                _entities.SaveChanges();
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
            var productToDelete = (from p in _entities.ProductSet
                                 where p.Id == id
                                 select p).FirstOrDefault();
            return View(productToDelete);
        }

        //
        // POST: /Home/Delete/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(Product productToDelete)
        {
            try
            {
                var originalProduct = (from p in _entities.ProductSet
                                       where p.Id == productToDelete.Id
                                       select p).FirstOrDefault();

                _entities.DeleteObject(originalProduct);
                _entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    
    
    }
}
