using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using WebApplication1.Data;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        [WebMethod]
        public static List<Customer> GetCustomers() 
        {            
            using (var dc = new NorthwindDataContext())
            {
                var query = from p in dc.Customers
                            select p;
                return query.ToList();
            }
        }

        [WebMethod]
        public static List<Product> GetProducts()
        {
            using (var dc = new NorthwindDataContext())
            {
                var query = from p in dc.Products
                            select p;
                return query.ToList();
            }
        }       
    }
}
