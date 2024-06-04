using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcFakes;
using Paging;

namespace MvcApplication1.Tests.Helpers
{
    [TestClass]
    public class DataGridHelperTests
    {

        public List<Product> CreateItems(int count)
        {
            var items = new List<Product>();
            for (var i=0;i < count;i++)
            {
                var newProduct = new Product();
                newProduct.Id = i;
                newProduct.Name = String.Format("Product {0}", i);
                newProduct.Price = count - i;
                items.Add(newProduct);
            }
            return items;
        }


        [TestMethod]
        public void SecondPageNumberSelected()
        {
            // Arrange
            var items = CreateItems(5);
            var data = items.AsQueryable().ToPagedList(1, 2); 

            // Act
            var fakeHtmlHelper = new FakeHtmlHelper();
            var results = DataGridHelper.DataGrid<Product>(fakeHtmlHelper, data);

            // Assert
            StringAssert.Contains(results, "<strong>2</strong>");
        
        }


        [TestMethod]
        public void CorrectNumberOfRows()
        {
            // Arrange
            var items = CreateItems(5);
            var data = items.AsQueryable().ToPagedList(1, 2);

            // Act
            var fakeHtmlHelper = new FakeHtmlHelper();
            var results = DataGridHelper.DataGrid<Product>(fakeHtmlHelper, data);

            // Assert (1 header row + 2 data rows + 1 pager row)
            Assert.AreEqual(4, Regex.Matches(results, "<tr>").Count);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
