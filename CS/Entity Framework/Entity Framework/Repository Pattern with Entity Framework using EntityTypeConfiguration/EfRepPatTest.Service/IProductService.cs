using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfRepPatTest.Entity;

namespace EfRepPatTest.Service
{
    public interface IProductService
    {
        List<Product> GetAll();
        void Insert(Product model);
        void Update(Product model);
    }
}
