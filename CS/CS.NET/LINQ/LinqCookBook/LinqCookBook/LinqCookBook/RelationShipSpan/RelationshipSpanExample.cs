using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.RelationshipSpan;
using Microsoft.Data.Extensions;
using System.Diagnostics;

namespace LinqCookBook.RelationShipSpan
{
    public class RelationshipSpanExample
    {
        static void CleanUp()
        {
            var db = new RsCustomerEntities();
            var cmd = db.CreateStoreCommand("delete rs.Phone;delete rs.customeraddress;delete rs.employeeaddress;delete rs.address;delete rs.Customer;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        
        public static void Run()
        {
            CleanUp();
            InsertCustomerAndPhone();
            //Example1();
            //Example2();
            //Example3();
           // Example4NoTracking();
            //Example5();
            //Example6();
            Examle7();
        }

        private static void Examle7()
        {
            var db = new RsCustomerEntities();
            var customers = db.Customers.ToList();
            var phones = db.Phones.Where("it.Number like '%455%'").ToList();
            foreach (var customer in customers)
            {
                if (!customer.Phones.IsLoaded)
                {
                    customer.Phones.Load();
                }
                Console.WriteLine("Customer:{0} Total Phones:{1}", customer.Name, customer.Phones.Count());
            }
        }

        private static void Example6()
        {
            var db = new RsCustomerEntities();
            var customers = db.Customers.ToList();
            var phones = db.Phones.Where("it.Number like '%455%'").ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine("Customer:{0} Total Phones:{1}", customer.Name, customer.Phones.Count());
            }
        }


        private static void Example5()
        {
            var db = new RsCustomerEntities();
            var customers = db.Customers.ToList();
            var phones = db.GetPhones().ToList();
            db.Refresh(System.Data.Objects.RefreshMode.ClientWins, phones);
            
            //customers.ForEach(c => c.Phones.Attach(
            //    phones.Where(p => Convert.ToInt32(p.CustomerReference.EntityKey.EntityKeyValues[0]) == c.CustomerId)));
            foreach (var customer in customers)
            {
                Console.WriteLine("Customer:{0} Total Phones:{1}", customer.Name, customer.Phones.Count());
            }
        }

        private static void Example4NoTracking()
        {
            var db = new RsCustomerEntities();
        }

        private static void Example3()
        {
            var db = new RsCustomerEntities();
            var addressquery = db.CreateQuery<Address>("select value top(1) a from RsCustomerEntities.Addresses as a");
            var address = addressquery.Execute(System.Data.Objects.MergeOption.NoTracking).First();
            
            Console.WriteLine(address.FullAddress);
            //in order to modify the address it needs to be tracked so attached the address entity'
            db.Attach(address);
            address.FullAddress = "address changed";
            db.SaveChanges();


            
        }

        private static void Example2()
        {
            var db = new RsCustomerEntities();
            var phones = db.Phones.ToList();
            var customers = db.Customers.ToList();
            foreach (var phone in db.Phones)
            {
                db.DeleteObject(phone);
            }
            foreach (var customer  in customers)
            {
                Console.WriteLine("Customer:{0} Total Phones:{1}",customer.Name,customer.Phones.Count());
            }
        }

        private static void Example1()
        {
            var db = new RsCustomerEntities();
            var phones = db.Phones.ToList();
            var customers = db.Customers.ToList();
            foreach (var customer in customers)
            {
                
                Console.WriteLine("Customer:{0} Total Phones:{1}",customer.Name,customer.Phones.Count());
            }
        }

        private static void InsertCustomerAndPhone()
        {
            var db = new RsCustomerEntities();
            var customer1 = new Customer
            {
                Name = "Zeeshan",
                Phones =
                {
                    new Phone{Number = "123-455-9876"},
                    new Phone{Number = "123-465-9877"},
                },
                Address = {new Address { AddressType = "HA", FullAddress = "Happy St" }}
            };

            var customer2 = new Customer
            {
                Name = "Alex",
                Phones =
                {
                    new Phone{Number = "123-465-9878"},
                    new Phone{Number = "123-455-9879"}
                },
                Address = {new Address{AddressType ="HA",FullAddress ="Happy St2"}}
            };
            var employee = new Employee { Name = "John", Address = { new Address { AddressType = "SA", FullAddress = "Shipping Address" } } };
            db.AddToCustomers(customer1);
            db.AddToCustomers(customer2);
            db.SaveChanges();
        }
    }
}
