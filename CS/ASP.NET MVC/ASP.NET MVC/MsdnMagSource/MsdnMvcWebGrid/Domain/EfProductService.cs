using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MsdnMvcWebGrid.Domain
{
    public class EfProductService : IProductService
    {
        // helpers that take an IQueryable<Product> and a bool to indicate ascending/descending
        // and apply that ordering to the IQueryable and return the result
        private readonly IDictionary<string, Func<IQueryable<Product>, bool, IOrderedQueryable<Product>>>
            _productOrderings = new Dictionary<string, Func<IQueryable<Product>, bool, IOrderedQueryable<Product>>>
                                    {
                                        {"Name", CreateOrderingFunc<Product, string>(p=>p.Name)},
                                        {"ListPrice", CreateOrderingFunc<Product, decimal?>(p=>p.ListPrice)}
                                    };
        /// <summary>
        /// returns a Func that takes an IQueryable and a bool, and sorts the IQueryable (ascending or descending based on the bool).
        /// The sort is performed on the property identified by the key selector.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        private static Func<IQueryable<T>, bool, IOrderedQueryable<T>> CreateOrderingFunc<T, TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return
                (source, ascending) =>
                ascending
                    ? source.OrderBy(keySelector)
                    : source.OrderByDescending(keySelector);
        }


        public Product GetProduct(int productId, bool includeCategory)
        {
            using (AdventureWorksLTEntities context = new AdventureWorksLTEntities())
            {
                ObjectQuery<Product> products = context.Products;
                if (includeCategory)
                {
                    products = products.Include("Category");
                }
                return products.FirstOrDefault(p => p.ProductId == productId);
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            using (AdventureWorksLTEntities context = new AdventureWorksLTEntities())
            {
                return context.Products
                    .OrderBy(p=>p.Name)
                    .ToList();
            }
        }

        public IEnumerable<Product> GetProducts(out int totalRecords, int pageSize, int pageIndex, string sort, SortDirection sortOrder)
        {
            using (AdventureWorksLTEntities context = new AdventureWorksLTEntities())
            {
                IQueryable<Product> products = context.Products;

                totalRecords = products.Count();

                // apply sorting
                Func<IQueryable<Product>, bool, IOrderedQueryable<Product>> applyOrdering = _productOrderings[sort];
                products = applyOrdering(products, sortOrder == SortDirection.Ascending);

                if (pageSize > 0 && pageIndex >= 0)
                {
                    // apply paging
                    products = products.Skip(pageIndex * pageSize).Take(pageSize);
                }

                return products.ToList();
            }
        }
    }
}