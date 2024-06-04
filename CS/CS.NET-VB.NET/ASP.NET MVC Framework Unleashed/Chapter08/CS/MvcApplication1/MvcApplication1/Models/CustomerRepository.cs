using System.Collections.Generic;
using System.Linq;

namespace MvcApplication1.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomersDBEntities _entities = new CustomersDBEntities();

        public IEnumerable<Customer> ListCustomers()
        {
            return _entities.CustomerSet.ToList();
        }

        public void CreateCustomer(Customer customerToCreate)
        {
            _entities.AddToCustomerSet(customerToCreate);
            _entities.SaveChanges();
        }

    }

    public interface ICustomerRepository
    {
        IEnumerable<Customer> ListCustomers();
        void CreateCustomer(Customer customerToCreate);
    }
}
