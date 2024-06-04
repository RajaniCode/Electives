using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericRepository.Tests.MemoryDatabaseTests
{
    [TestClass]
    public class InsertTests
    {

        [TestMethod]
        public void AfterFirstInsertIdIs1()
        {
            // Arrange
            var db = new MemoryDatabase();
            var productToInsert = new Product();
            
            // Act
            db.Insert<Product>(productToInsert);

            // Assert
            Assert.AreEqual(1, productToInsert.Id);
        }


        [TestMethod]
        public void InsertIncrementsId()
        {
            // Arrange
            var db = new MemoryDatabase();

            // Act
            var productToInsert1 = new Product();
            db.Insert<Product>(productToInsert1);
            var productToInsert2 = new Product();
            db.Insert<Product>(productToInsert2);
            var productToInsert3 = new Product();
            db.Insert<Product>(productToInsert3);

            // Assert
            Assert.AreEqual(1, productToInsert1.Id);
            Assert.AreEqual(2, productToInsert2.Id);
            Assert.AreEqual(3, productToInsert3.Id);
        }



        [TestMethod]
        public void InsertFirstListFirst()
        {
            // Arrange
            var db = new MemoryDatabase();

            // Act
            var productToInsert1 = new Product();
            db.Insert<Product>(productToInsert1);
            var productToInsert2 = new Product();
            db.Insert<Product>(productToInsert2);
            var productToInsert3 = new Product();
            db.Insert<Product>(productToInsert3);

            // Assert
            var firstProduct = db.Select<Product>().FirstOrDefault();
            Assert.AreEqual(1, firstProduct.Id);
        }


    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
