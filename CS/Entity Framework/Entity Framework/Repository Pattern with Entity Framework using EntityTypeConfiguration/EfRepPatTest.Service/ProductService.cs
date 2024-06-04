using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfRepPatTest.Data;
using EfRepPatTest.Entity;

namespace EfRepPatTest.Service
{
    public class ProductService:IProductService
    {
        private IDbContext dbContext = new DataContext();
        private IRepository<Product> productRepository;

        public ProductService()
        {
            productRepository = new RepositoryService<Product>(dbContext);

        }
        public List<Product> GetAll()
        {
            return productRepository.GetAll().ToList();
        }

        public void Insert(Product model)
        {
            productRepository.Insert(model);
        }


        public void Update(Product model)
        {
            productRepository.Update(model);
        }
    }
}
