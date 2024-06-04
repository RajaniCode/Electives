using System.Linq;

namespace Paging
{
    public partial class Northwind
    {
        private NorthwindDataContext Context
        {
            get;
            set;
        }

        public Northwind()
        {
            Context = new NorthwindDataContext();
        }

        public int GetCustomerCount(int maximumRows, int startPageIndex, int startRowIndex)
        {
            return Context.Customers.Count();
        }
        
        public IQueryable<Customer> GetCustomers(int maximumRows, int startPageIndex, int startRowIndex)
        {
            var query = Context.Customers.Skip(startRowIndex).Take(maximumRows);
            return query;            
        }
    }
}
