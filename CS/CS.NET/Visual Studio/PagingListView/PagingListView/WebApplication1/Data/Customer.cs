using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Data
{
    public partial class Customer
    {       
        public int GetCustomerCount()
        {
            int totalCount = 0;
            object o = HttpContext.Current.Cache["TotalCount"];
            if (o == null)
            {
                using (NorthwindDataContext dc = new NorthwindDataContext())
                {
                    totalCount = dc.Customers.Count();
                    HttpContext.Current.Cache["TotalCount"] = totalCount;
                }
            }
            else
            {
                totalCount = (int)o;
            }
            return totalCount;            
        }

        public List<Customer> GetCustomers(int maximumRows, int startRowIndex)
        {
            using (NorthwindDataContext dc = new NorthwindDataContext())
            {
                return dc.Customers.Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }

        public void UpdateCustomer(string CustomerID, string CompanyName, 
                        string ContactName, string ContactTitle, string Address, 
                        string City, string Region, int PostalCode, string Country,
                        string Phone, string Fax)
        {
            using (NorthwindDataContext dc = new NorthwindDataContext())
            {
                Customer customer = dc.Customers.Single(o => o.CustomerID == CustomerID);
                customer.CompanyName = CompanyName;
                customer.ContactName = ContactName;
                customer.ContactTitle = ContactTitle;
                customer.Address = Address;
                customer.City = City;
                customer.Region = Region;
                customer.PostalCode = PostalCode.ToString();
                customer.Country = Country;
                customer.Phone = Phone;
                customer.Fax = Fax;
                dc.SubmitChanges();
            }
        }
    }
}
