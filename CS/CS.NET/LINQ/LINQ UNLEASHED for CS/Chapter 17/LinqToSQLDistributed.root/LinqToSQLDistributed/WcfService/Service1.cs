using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace WcfService
{
  public class Service1 : IService1
  {
    public List<Customer> GetCustomers()
    {
      Northwind northwind = new Northwind();
      Table<Customer> customers = northwind.GetTable<Customer>();
      return customers.ToList();
    }

    public void UpdateCustomer(Customer original, Customer modified)
    {
      Northwind northwind = new Northwind();
      Table<Customer> customers = northwind.GetTable<Customer>();
      customers.Attach(modified, original);
      northwind.SubmitChanges();
    }
  }
}
