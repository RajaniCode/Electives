using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc2Grid.Models
{
    public class ProductsRepositoryEF : IProductsRepository
    {
        #region IProductsRepository Members
        private NORTHWNDEntities _db = new NORTHWNDEntities();
        public IQueryable<Products> Products
        {
            get
            {
                return _db.Products;
            }
            set
            {
                
            }
        }

        #endregion
    }
}
