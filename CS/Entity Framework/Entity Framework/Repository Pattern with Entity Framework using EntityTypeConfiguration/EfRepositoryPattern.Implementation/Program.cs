using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfRepPatTest.Data;
using EfRepPatTest.Data.DbInitializer;
using EfRepPatTest.Entity;
using EfRepPatTest.Service;

namespace EfRepPatTest.Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DataContext();
            var dataBaseInitializer = new DataBaseInitializer();
            dataBaseInitializer.InitializeDatabase(context);

            var categoryRepository = new RepositoryService<Category>(context);

            //Adding category in the category entity
            var category = new Category()
            {
                Name = "Baverage"
            };
            var products = new List<Product>();

            //Adding product in the product entity
            var product = new Product()
                {
                    Name = "Soft Drink A",
                    MinimumStockLevel = 50
                };
            products.Add(product);

            product = new Product()
            {
                Name = "Soft Drink B",
                MinimumStockLevel = 30
            };
            products.Add(product);

            category.Products = products;

            //Insert category and save changes
            categoryRepository.Insert(category);
            context.SaveChanges();



            ///////////////////////////////////////////////////////////////////////////////
            /////////////////For the next project we shall add Dependency Injection////////
            ////////////////But now we have add a Service layer for test manually//////////
            ///////////////////////////////////////////////////////////////////////////////
            IProductService productRepository = new ProductService();

            Console.WriteLine("\n");
            Console.WriteLine("Product List:");
            Console.WriteLine("-------------------------------------------------");
            foreach (var product1 in productRepository.GetAll())
            {
                Console.WriteLine(string.Format("Product Name : {0}",product1.Name));
                if (product1.Id == 9)
                {

                    product1.Name = "Soft Drink AAA";
                    productRepository.Update(product1);
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        
    }
}
