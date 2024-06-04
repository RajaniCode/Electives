using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericRepository.Tests.MemoryDatabaseTests
{
    [TestClass]
    public class DeleteTests
    {

        [TestMethod]
        public void CanDelete()
        {
            // Arrange
            var db = new MemoryDatabase();
            var productToInsert1 = new Product();
            db.Insert<Product>(productToInsert1);
            var productToInsert2 = new Product();
            db.Insert<Product>(productToInsert2);
            var productToInsert3 = new Product();
            db.Insert<Product>(productToInsert3);

            // Act
            db.Delete<Product>(productToInsert2);

            // Assert
            Assert.AreEqual(2, db.Select<Product>().Count());
        }




    }
}
