using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWComplexTypeModel;

namespace LinqCookBook.Examples
{
    public class ComplexTypeExample
    {
        private static void CleanUp()
        {
            var db = new NWComplexTypeEntities();
            var cus = db.Customers.FirstOrDefault(c => c.CustomerID == "COML1");
            var emp = db.Employees.FirstOrDefault(e => e.FirstName == "Zeeshan" && e.LastName == "Hirani");
            if (cus != null)
            {
                db.DeleteObject(cus);
            }
            if (emp != null)
            {
                db.DeleteObject(emp);
            }
            db.SaveChanges();
        }
        public static void RunComplexTypeExamples()
        {
            CleanUp();
             var db = new NWComplexTypeEntities();
            Console.WriteLine("First 2 customer address info");
            foreach (var cus in db.Customers.Take(2))
            {
                Console.WriteLine("City:{0} Zip:{1}",cus.Address.City,cus.Address.PostalCode);
            }
            Console.WriteLine("\r\nFirst 2 employee address info");
            foreach (var emp in db.Employees.Take(2))
            {
                Console.WriteLine("City:{0} Zip:{1}", emp.Address.City, emp.Address.PostalCode);
            }
            //insert customer
            var customer = new NWComplexTypeModel.Customer
            {
                CustomerID = "COML1",
                CompanyName = "Test Company",
                Address = new CommonAddress
                {
                     Address = "address 1",
                     City = "Euless",
                     Country="USA"
                }
            };
            db.AddToCustomers(customer);
            
            //insert employee
            var employee = new Employee 
            { 
                FirstName = "Zeeshan", 
                LastName = "Hirani" 
            };
            employee.Address.Address = "address 1";
            employee.Address.City = "Euless";
            employee.Address.Country = "USA";
            db.AddToEmployees(employee);
            db.SaveChanges();

            //querying using complex type.
            var cusquery = db.Customers.First(c => c.Address.City == "Euless" && c.Address.Country == "USA");
            Console.WriteLine("Using Complex type in queries");
            Console.WriteLine(cusquery.CustomerID);
        }

        public static void UsingNestedComplexType()
        {
            var db = new NWNestedComplexTypeModel.NWComplexTypeEntities();
            var cus = db.Customers.First(c => c.Address.Address.Contains("Obere Str") && c.Address.AdditonalInfo.Country == "Germany");
            Console.WriteLine(cus.Address.AdditonalInfo.City);
        }
    }
}
