using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MsdnMvcWebGrid.Domain;
using MsdnMvcWebGrid.Infrastructure;
using MsdnMvcWebGrid.Models.Product;

namespace MsdnMvcWebGrid.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        // NOTE: In the magazine article I showed a "List" action, but to easily demonstrate the various approaches I have changed the action name to match the approach being shown (e.g. BasicWebGrid, ...)

        public ProductController()
            : this(new Domain.EfProductService()) // NOTE: would typically add a DI container and Dependency resolver to remove the need for this constructor
        {

        }
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Details(int id)
        {
            ProductDetailsModel model = new ProductDetailsModel
                            {
                                Product = _productService.GetProduct(id, includeCategory: true)
                            };
            return View(model);
        }

        public ActionResult BasicWebGrid()
        {
            IEnumerable<Product> model =
                _productService.GetProducts();

            return View(model);
        }
        public ActionResult BasicWebGridWebForms()
        {
            IEnumerable<Product> model =
                _productService.GetProducts();

            return View(model);
        }


        public ActionResult BasicStronglyTypedWebGrid()
        {
            IEnumerable<Product> model =
                _productService.GetProducts();

            return View(model);
        }

        public ActionResult BasicStronglyTypedWebGridWebForms()
        {
            IEnumerable<Product> model =
                _productService.GetProducts();

            return View(model);
        }


        public ActionResult DefaultPagingAndSorting()
        {
            IEnumerable<Product> model =
                _productService.GetProducts();

            return View(model);
        }
        public ActionResult ServerPaging(int page = 1)
        {
            const int pageSize = 5;

            int totalRecords;
            IEnumerable<Product> products =
                _productService.GetProducts(out totalRecords, pageSize: pageSize, pageIndex: page - 1);

            PagedProductsModel model = new PagedProductsModel
            {
                PageSize = pageSize,
                PageNumber = page,
                Products = products,
                TotalRows = totalRecords
            };
            return View(model);
        }
        public ActionResult ServerPagingAndSorting(int page = 1, string sort = "Name", string sortDir = "Ascending" )
        {
            const int pageSize = 5;

            int totalRecords;
            IEnumerable<Product> products =
                _productService.GetProducts(out totalRecords,
                                            pageSize: pageSize,
                                            pageIndex: page - 1,
                                            sort:sort,
                                            sortOrder:GetSortDirection(sortDir)
                                            );

            PagedProductsModel model = new PagedProductsModel
            {
                PageSize = pageSize,
                PageNumber = page,
                Products = products,
                TotalRows = totalRecords
            };
            return View(model);
        }

        public ActionResult StandardAjax(int page = 1, string sort = "Name", string sortDir = "Ascending")
        {
            const int pageSize = 5;

            int totalRecords;
            IEnumerable<Product> products =
                _productService.GetProducts(out totalRecords,
                                            pageSize: pageSize,
                                            pageIndex: page - 1,
                                            sort: sort,
                                            sortOrder: GetSortDirection(sortDir)
                                            );

            PagedProductsModel model = new PagedProductsModel
            {
                PageSize = pageSize,
                PageNumber = page,
                Products = products,
                TotalRows = totalRecords
            };
            return View(model);
        }

        public ActionResult CustomAjax(int page = 1, string sort = "Name", string sortDir = "Ascending")
        {
            const int pageSize = 5;

            int totalRecords;
            IEnumerable<Product> products =
                _productService.GetProducts(out totalRecords,
                                            pageSize: pageSize,
                                            pageIndex: page - 1,
                                            sort: sort,
                                            sortOrder: GetSortDirection(sortDir)
                                            );

            PagedProductsModel model = new PagedProductsModel
            {
                PageSize = pageSize,
                PageNumber = page,
                Products = products,
                TotalRows = totalRecords
            };
            if (Request.IsAjaxRequest())
            {
                return PartialView("CustomAjax_Grid",model);
            }
            return View(model);
        }

        
        private SortDirection GetSortDirection(string sortDirection)
        {
            if (sortDirection != null)
            {
                if (sortDirection.Equals("DESC", StringComparison.OrdinalIgnoreCase) ||
                    sortDirection.Equals("DESCENDING", StringComparison.OrdinalIgnoreCase))
                {
                    return  SortDirection.Descending;
                }
            }
            return SortDirection.Ascending;
        }
    }
}