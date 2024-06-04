using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcApplication1.Models;
using Paging;

namespace MvcApplication1.Controllers
{
    public class ProductController : Controller
    {
        private ToyStoreDBEntities _entities = new ToyStoreDBEntities(); 

        public ActionResult Index()
        {
            return View(_entities.ProductSet.ToList());
        }


        public ActionResult List()
        {
            ViewData["products"] = _entities.ProductSet.ToList(); 
            return View();
        }



        public ActionResult SortProducts(string sort)
        {
            IEnumerable<Product> products;
            sort = sort ?? string.Empty;
            switch (sort.ToLower())
            {
                case "name":
                    products = from p in _entities.ProductSet 
                               orderby p.Name select p;
                    break;
                case "price":
                    products = from p in _entities.ProductSet
                               orderby p.Price
                               select p;
                    break;
                default:
                    products = from p in _entities.ProductSet
                               orderby p.Id
                               select p;
                    break;
            }

            return View(products);
        }


        public ActionResult PagedProducts(int? page)
        {
            var products = _entities.ProductSet
                .OrderBy(p => p.Id).ToPagedList(page, 2);
            
            return View(products);
        }


        public ActionResult PagedSortedProducts(string sort, int? page)
        {
            IQueryable<Product> products;
            sort = sort ?? string.Empty;
            switch (sort.ToLower())
            {
                case "name":
                    products = from p in _entities.ProductSet
                               orderby p.Name
                               select p;
                    break;
                case "price":
                    products = from p in _entities.ProductSet
                               orderby p.Price
                               select p;
                    break;
                default:
                    products = from p in _entities.ProductSet
                               orderby p.Id
                               select p;
                    break;
            }

            ViewData.Model = products.ToPagedList(page, 2, sort);
            return View();
        }






    }
}
