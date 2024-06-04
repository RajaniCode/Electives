using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using LinqToSQLDistributed.ServiceReference1;
using System.Reflection;


namespace LinqToSQLDistributed
{
  class Program
  {
    static void Main(string[] args)
    {
      IService1 serv = new Service1Client();
      Customer[] customers = serv.GetCustomers();

      var alfki = (from customer in customers
                  where customer.CustomerID == "ALFKI"
                  select customer).Single();

      //030-0076545
      Customer original = Clone(alfki);
      alfki.Fax = "030-0076541";
      serv.UpdateCustomer(original, alfki);
      

    }

     public static T Clone<T>(T toClone) where T : new()
    {
      T target = new T();
      
      PropertyInfo[] properties = toClone.GetType().GetProperties();
      foreach(PropertyInfo property in properties)
      {
        PropertyInfo targetProperty = target.GetType()
          .GetProperty(property.Name);

        targetProperty.SetValue(target, 
          property.GetValue(toClone, null), null);

      }

      return target;
    }
  }
}
