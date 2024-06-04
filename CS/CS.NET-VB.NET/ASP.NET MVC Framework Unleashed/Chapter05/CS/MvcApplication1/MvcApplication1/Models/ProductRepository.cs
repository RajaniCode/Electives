using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ProductRepository : IProductRepository
    {
        private ProductsDBEntities _entities = new ProductsDBEntities();

        #region IProductRepository Members

        public IEnumerable<Product> List()
        {
            return _entities.ProductSet.ToList();
        }

        public Product Get(int id)
        {
            return (from p in _entities.ProductSet
                          where p.Id == id
                          select p).FirstOrDefault();
        }

        public void Create(Product productToCreate)
        {
            _entities.AddToProductSet(productToCreate);
            _entities.SaveChanges();
        }

        public void Edit(Product productToEdit)
        {
            var originalProduct = Get(productToEdit.Id);
            _entities.ApplyPropertyChanges(originalProduct.EntityKey.EntitySetName, productToEdit);
            _entities.SaveChanges();

        }

        public void Delete(Product productToDelete)
        {
            var originalProduct = Get(productToDelete.Id);
            _entities.DeleteObject(originalProduct);
            _entities.SaveChanges();
        }

        #endregion
    }
}
