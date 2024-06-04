using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.Helpers;
using MvcApplication1.Models;
using MvcFakes;

namespace MvcApplication1.Tests.Helpers
{
    [TestClass]
    public class ProductHelperTest
    {
        [TestMethod]
        public void ContainsHtmlRow()
        {
            // Arrange products
            var products = new List<Product>();
            products.Add(Product.CreateProduct(-1, "Laptop", "A laptop", 878.23m));
            products.Add(Product.CreateProduct(-1, "Telescope", "A telescape", 200.19m));

            // Arrange HTML helper
            var helper = new FakeHtmlHelper();
            helper.ViewData.Model = products;

            // Act
            var result = ProductHelper.ProductList(helper);
        
            // Assert
            StringAssert.Contains(result, "<td>Laptop</td><td>$878.23</td>");
        }
    }
}
