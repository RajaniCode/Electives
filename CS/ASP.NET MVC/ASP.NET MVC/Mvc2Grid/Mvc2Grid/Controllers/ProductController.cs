using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using Mvc2Grid.Models;

namespace Mvc2Grid.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _repository;
        private int _pageSize;
        public ProductController()
            : this(new ProductsRepositoryEF())
        {

        }

        public ProductController(IProductsRepository repository)
        {
            _repository = repository;
            _pageSize = 10;
        }

        public ActionResult List(string sort, int? page)
        {
            var currentPage = page ?? 1;
            ViewData["SortItem"] = sort;
            sort = sort ?? "Name";
            ViewData["CurrentPage"] = currentPage;
            ViewData["TotalPages"] = (int)Math.Ceiling((float)_repository.Products.Count() / _pageSize);

            var products = from p in _repository.Products
                           select new ProductViewModel()
                           {
                               Name = p.ProductName,
                               Price = p.UnitPrice ?? 0,
                               Category = p.Category.CategoryName
                           };
            var sortedProducts = products
                .OrderBy(sort)
                .Skip((currentPage - 1) * _pageSize)
                .Take(_pageSize);
            return View(sortedProducts);
        }
    }
}
