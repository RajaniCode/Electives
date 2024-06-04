using System.Linq;
using System.Web.Services;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        [WebMethod]
        public static CustomerData FetchCustomers(int skip, int take)
        {
            var data = new CustomerData();
            using (var dc = new NorthwindDataContext())
            {
                var query = (from p in dc.Customers
                            select p)
                            .Skip(skip)
                            .Take(take)                            
                            .ToList();
                data.Customers = query;
                data.TotalRecords = (from p in dc.Customers
                                     select p).Count();
            }
            return data;
        }        
    }
}
