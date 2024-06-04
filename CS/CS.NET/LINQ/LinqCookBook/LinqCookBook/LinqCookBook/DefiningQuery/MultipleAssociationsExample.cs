using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.DefiningQuery;

namespace LinqCookBook.DefiningQuery
{
    public class MultipleAssociationsExample
    {
        public static void Run()
        {
            var db = new MultipleAssoEntities();
            var contact = db.Contacts
                            .Include("BillingAddress").Include("ShippingAddress")
                            .First(c => c.ContactName == "Zeeshan");
            Console.WriteLine("Name: {0}",contact.ContactName);
            Console.WriteLine("Billing: {0}",contact.BillingAddress.FullAddress);
            Console.WriteLine("Shipping: {0}",contact.ShippingAddress.FullAddress);
        }
    }
}
