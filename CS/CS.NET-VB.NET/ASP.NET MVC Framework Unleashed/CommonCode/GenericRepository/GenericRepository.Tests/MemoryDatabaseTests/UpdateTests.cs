using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericRepository.Tests.MemoryDatabaseTests
{
    [TestClass]
    public class UpdateTests
    {

        [TestMethod]
        public void CanUpdate()
        {
            // Arrange
            var db = new MemoryDatabase();
            var productToInsert1 = new Product();
            db.Insert<Product>(productToInsert1);
            var productToInsert2 = new Product();
            db.Insert<Product>(productToInsert2);
            var productToInsert3 = new Product();
            db.Insert<Product>(productToInsert3);
    
            // Get original
            var originalProduct = db.Select<Product>().Where(p=>p.Id == 2).Select(p => p).FirstOrDefault();

            // Create modified
            var modifiedProduct = new Product();
            modifiedProduct.Name = "Modified";

            // Update
            db.Update<Product>(originalProduct, modifiedProduct);

            // Get original
            originalProduct = db.Select<Product>().Where(p => p.Id == 2).Select(p => p).FirstOrDefault();

            // Assert
            Assert.AreEqual("Modified", originalProduct.Name);
        }

    
    
    }
}
