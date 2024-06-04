using System;
using System.Web.Mvc;
using EFMvcApplication.Controllers;
using EFMvcApplication.Models;
using GenericRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EFMvcApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTestMock
    {
        private Mock<IGenericRepository> _mockRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IGenericRepository>();
        }

        [TestMethod]
        public void NameIsRequired()
        {
            // Arrange
            var controller = new HomeController(_mockRepository.Object);
            var productToCreate = new Product();
            productToCreate.Name = String.Empty;

            // Act
            var result = (ViewResult)controller.Create(productToCreate);

            // Assert
            var modelStateError = result.ViewData.ModelState["Name"].Errors[0].ErrorMessage;
            Assert.AreEqual("Product name is required.", modelStateError);
        }
    }
}
