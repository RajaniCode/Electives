using MVC3Demo.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Mvc;
using MVC3Demo.Models;
using System.Collections;
using System.Collections.Generic;

namespace MVC3Demo.Test
{


    /// <summary>
    ///This is a test class for ProductControllerTest and is intended
    ///to contain all ProductControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
       
        [TestMethod]
        public void ProductListTest()
        {
            ProductController target = new ProductController();
            ProductModel actualProductModel = new ProductModel();

            string strPrdCode = string.Empty;
            ActionResult actual;
            actual = target.ProductList();

            Assert.IsInstanceOfType(actual, typeof(PartialViewResult));

            PartialViewResult result = (PartialViewResult)actual;
            Assert.IsInstanceOfType(result.Model, typeof(IList<ProductModel>));

            IList<ProductModel> expectedProduct = (IList<ProductModel>)result.Model;
            IList<ProductModel> actualProduct = (IList<ProductModel>)actualProductModel.GetAllProducts();

            Assert.AreEqual(actualProduct.Count, expectedProduct.Count);
        }

        [TestMethod]
        public void ProductDetailTest()
        {
            ProductController target = new ProductController();
            ProductModel actualProductModel = new ProductModel();
            ProductModel actualProduct = actualProductModel.GetAllProducts()[0];

            string strPrdCode = string.Empty;
            ActionResult actual;
            actual = target.ProductDetail(strPrdCode);

            Assert.IsInstanceOfType(actual, typeof(PartialViewResult));

            PartialViewResult result = (PartialViewResult)actual;
            Assert.IsInstanceOfType(result.Model, typeof(ProductModel));

            ProductModel expectedProduct = (ProductModel)result.Model;

            Assert.AreEqual(actualProduct.PrdCode, expectedProduct.PrdCode);
            Assert.AreEqual(actualProduct.Name, expectedProduct.Name);
            Assert.AreEqual(actualProduct.Price, expectedProduct.Price);
        }


    }
}
