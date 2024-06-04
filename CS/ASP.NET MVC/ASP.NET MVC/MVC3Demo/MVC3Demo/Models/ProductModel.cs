using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MVC3Demo.Models
{
    public class ProductModel
    {
        [DisplayName("Product Code")]
        public int PrdCode { get; set; }
        [DisplayName("Title")]
        public String Name { get; set; }
        [DisplayName("Price in $")]
        public double Price { get; set; }

        private IList<ProductModel> PRODUCTS
        {
            get
            {
                IList<ProductModel> prs = new List<ProductModel>() 
            { 
                new ProductModel()  { PrdCode =100001, Name ="Baby Product 1", Price =10},
                new ProductModel()  { PrdCode =100002, Name ="Baby Product 2", Price =11},
                new ProductModel()  { PrdCode =100003, Name ="Baby Product 3", Price =12},
                new ProductModel()  { PrdCode =100004, Name ="Baby Product 4", Price =13},
                new ProductModel()  { PrdCode =100005, Name ="Baby Product 5", Price =30},
                new ProductModel()  { PrdCode =100006, Name ="Baby Product 6", Price =30},
                new ProductModel()  { PrdCode =100007, Name ="Baby Product 7", Price =30},
                new ProductModel()  { PrdCode =100008, Name ="Baby Product 8", Price =20},
                new ProductModel()  { PrdCode =100009, Name ="Baby Product 9", Price =20},
                new ProductModel()  { PrdCode =100010, Name ="Baby Product 10", Price =20},
                new ProductModel()  { PrdCode =100011, Name ="Baby Product 11", Price =20},
                new ProductModel()  { PrdCode =100012, Name ="Baby Product 12", Price =30},
                new ProductModel()  { PrdCode =100013, Name ="Baby Product 13", Price =30},
                new ProductModel()  { PrdCode =100014, Name ="Baby Product 14", Price =20},
                new ProductModel()  { PrdCode =100015, Name ="Baby Product 15", Price =20},
                new ProductModel()  { PrdCode =100016, Name ="Baby Product 16", Price =30},
                new ProductModel()  { PrdCode =100017, Name ="Baby Product 17", Price =30},
                new ProductModel()  { PrdCode =100018, Name ="Baby Product 18", Price =30},
                new ProductModel()  { PrdCode =100019, Name ="Baby Product 19", Price =30},
                new ProductModel()  { PrdCode =100020, Name ="Baby Product 20", Price =30}                
            };

                return prs;
            }
        }

        public ProductModel GetAProduct(int prdCode)
        {
            ProductModel prd = PRODUCTS.Where(x => x.PrdCode == prdCode).Single<ProductModel>();

            return prd;
        }

        public IList<ProductModel> GetAllProducts()
        {
            return PRODUCTS;
        }

    }
}