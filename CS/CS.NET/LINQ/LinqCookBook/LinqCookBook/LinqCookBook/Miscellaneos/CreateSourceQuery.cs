using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.Miscellaneos;


namespace LinqCookBook.Miscellaneos
{
   public  class CreateSourceQuery
    {
       public static void Run()
       {
           Example1();
           Example2();
           Example3();
       }

       private static void Example3()
       {
           var db = new CRSContainer();
           var school = db.Schools.First(s => s.SchoolName == "Habib");
           var student = school.Persons
                               .CreateSourceQuery()
                               .OfType<Student>().Include("Courses")
                               .First();
           Console.WriteLine("Student:{0} Courses Enrolled:{1}", student.Name, student.Courses.Count());
       }

       private static void Example2()
       {
           var db = new CSQEntities();
           var cust = db.Customers.First(c => c.CustomerID == "ALFKI");
           var totalorders = cust.Orders.CreateSourceQuery().Count();
           Console.WriteLine("Total Orders:{0}",totalorders);
       }

       private static void Example1()
       {
           var db = new CSQEntities();
           var cust = db.Customers.First(c => c.CustomerID == "ALFKI");

           var orders = cust.Orders.CreateSourceQuery()
                       .Include("OrderDetails")
                       .Where(o => o.Freight > 30.0M)
                       .OrderBy(o => o.OrderDate);
           cust.Orders.Attach(orders);
           foreach (var order in cust.Orders)
           {
               Console.WriteLine("OrderID:{0} Freight:{1}", order.OrderID, order.Freight);
               Console.WriteLine("   Total OrderDetails:{0}\r\n", order.OrderDetails.Count());
           }
       }
    }
}
