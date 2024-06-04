using System.Collections;
using System.Web.Mvc;
using EFMvcApplication.Controllers;
using EFMvcApplication.Models;
using GenericRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFMvcApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTestFake
    {
        IGenericRepository _fakeRepository; 

        [TestInitialize]
        public void Initialize()
        {
            _fakeRepository = new FakeGenericRepository();
        }

        [TestMethod]
        public void CreateThenList()
        {
            // Arrange
            var controller = new HomeController(_fakeRepository);
            var productToCreate = Product.CreateProduct(-1, "Test", "Test", 3.44m); 

            // Act
            controller.Create(productToCreate);
            var results = (ViewResult)controller.Index();

            // Assert
            var products = (ICollection)results.ViewData.Model;
            CollectionAssert.Contains(products, productToCreate);
        }
    }
}
