using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3Demo.Models;

namespace MVC3Demo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        ProductModel model = null;
        IList<ProductModel> AllProducts = null;

        public ProductController()
        {
            model = new ProductModel();
            AllProducts = model.GetAllProducts();
        }

        public ActionResult Index()
        {            
            return View();
        }
        
        public virtual ActionResult ProductList()
        {
            return PartialView("ProductList", AllProducts);
        }

        public virtual ActionResult ProductDetail(string strPrdCode)
        {
            int prdCode;

            if (!int.TryParse(strPrdCode, out prdCode))
                prdCode = 0;

            if (prdCode == 0)
                prdCode = AllProducts[0].PrdCode;

            var prd = model.GetAProduct(prdCode);
            return PartialView("ProductDetail", prd);
        }

    }
}
