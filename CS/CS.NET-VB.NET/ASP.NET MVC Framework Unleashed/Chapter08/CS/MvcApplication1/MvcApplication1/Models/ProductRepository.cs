using System.Collections.Generic;
using System.Linq;

namespace MvcApplication1.Models
{
    public class ProductRepository : IProductRepository
    {
        private ProductsDBEntities _entities = new ProductsDBEntities();

        public IEnumerable<Product> ListProducts()
        {
            return _entities.ProductSet.ToList();
        }

        public void CreateProduct(Product productToCreate)
        {
            _entities.AddToProductSet(productToCreate);
            _entities.SaveChanges();
        }

    }

    public interface IProductRepository
    {
        IEnumerable<Product> ListProducts();
        void CreateProduct(Product productToCreate);
    }
}
