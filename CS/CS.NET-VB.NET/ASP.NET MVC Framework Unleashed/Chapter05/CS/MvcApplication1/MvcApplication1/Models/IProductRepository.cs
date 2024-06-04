using System.Collections.Generic;

namespace MvcApplication1.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> List();
        Product Get(int id);
        void Create(Product productToCreate);
        void Edit(Product productToEdit);
        void Delete(Product productToDelete);
    }
}
