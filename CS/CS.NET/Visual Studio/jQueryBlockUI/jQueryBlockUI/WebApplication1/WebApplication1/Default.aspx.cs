using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Services;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        [WebMethod]
        public static List<Customer> FetchCustomers(string contactName)
        {
            var customers = new List<Customer>();
            using (var dc = new NorthwindDataContext() )
            {
                customers = (from p in dc.Customers
                             where p.ContactName.StartsWith(contactName)
                             select p).ToList();
            }

            for (int i = 0; i < 1; i++)
            {                
                Thread.Sleep(1000);
            }
            return customers;
        }  
    }
}
