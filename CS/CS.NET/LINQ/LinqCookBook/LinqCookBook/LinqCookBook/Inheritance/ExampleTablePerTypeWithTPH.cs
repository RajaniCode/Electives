using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inheritance.TBTAndTBH;
using Microsoft.Data.Extensions;


namespace LinqCookBook.Inheritance
{
    public class ExampleTablePerTypeWithTPH
    {
        static void CleanUp()
        {
            var db = new MediaTPTTBH();
            var cmd = db.CreateStoreCommand( "delete TBH.Articles;delete TBH.Videos;delete TBH.Medias;delete tbhc.Employees;delete Persons;" + 
            "delete tbhc.ManufacturerLocations;delete tbhc.Company;delete tbhc.Locations;delete tbhc.Manufacturers");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
           //TablePerTypeWithTPH();
           //TablePerHiearchyWithMultipleConditions();
           // ConditionsonBaseTable();
            //AdditionalAbstractEntity();
            AssocationOnDerivedEntity();
        }

        private static void AssocationOnDerivedEntity()
        {
            var db = new MediaTPTTBH();
            var manuflocation = new ManufacturerLocation
            {
                Address = "1001 FullerWiser",
                City = "Euless",
                State = "Tx",
                Manufacturer = new Manufacturer { Name = "Food Ltd" }
            };
            var company = new Company
            {
                Address="Mark blvd",
                City="Dallas",
                State = "Tx",
                CompanyName="EnergyDrinks"
            };
            db.AddToLocations(manuflocation);
            db.AddToLocations(company);
            db.SaveChanges();
            var db2 = new MediaTPTTBH();
            var manloc = db2.Locations.OfType<ManufacturerLocation>().Include("Manufacturer").First();
            var comp = db2.Locations.OfType<Company>().First();
            Console.WriteLine("Name {0} Address {1}",manloc.Manufacturer.Name,manloc.Address);
            Console.WriteLine("Name {0} Address {1}",comp.CompanyName,comp.Address);
        }

        private static void AdditionalAbstractEntity()
        {
            var db = new MediaTPTTBH();
            var cust = new Customer { Name = "Zee", IsClubMember = true };
            var instructor = new Instructor { HireDate = DateTime.Now, Name = "Alex" };
            var student = new Student { Name = "John", EnrollmentDate = DateTime.Now };
            db.AddToPersons(cust);
            db.AddToPersons(instructor);
            db.AddToPersons(student);
            db.SaveChanges();

            var db2 = new MediaTPTTBH();
            Console.WriteLine("Total Persons " + db2.Persons.Count());
            Console.WriteLine("Total Staff " + db2.Persons.OfType<Staff>().Count());
        }

        private static void ConditionsonBaseTable()
        {
            var db = new MediaTPTTBH();
            Console.WriteLine("Total Orders " + db.Orders.Count());
            Console.WriteLine("Deleted Orders " + db.Orders.OfType<DeletedOrders>().Count());
        }

        private static void TablePerHiearchyWithMultipleConditions()
        {
            var db = new MediaTPTTBH();
            var hourly = new HourlyEmployee { Name = "Zee", Hours = 40, Rate = 60 };
            var salary = new SalariedEmployee { Name = "Garg", Salary = 95000 };
            var salpluscomm = new SalComEmployee { Name = "Travis", Commission = 2000, Salary = 95000 };
            db.AddToEmployees(hourly);
            db.AddToEmployees(salary);
            db.AddToEmployees(salpluscomm);
            db.SaveChanges();
            var db2 = new MediaTPTTBH();
            Console.WriteLine("Total Employees " + db2.Employees.Count());

            var hourly1 = db.Employees.OfType<HourlyEmployee>().First();
            Console.WriteLine("Hourly Employee " + hourly1.Name);

            Console.WriteLine("Total Salaried Employee "  + db.Employees.OfType<SalariedEmployee>().Count());
            var salary1 = db.Employees.OfType<SalariedEmployee>().First();
            Console.WriteLine("Salaried Employee " + salary1.Name);

            var salpluscom1 = db.Employees.OfType<SalComEmployee>().First();
            Console.WriteLine("Sal plus Comm Employee " + salpluscom1.Name);
        }

        
       
        /// <summary>
        /// Example showing table Per Type used with table per hiearachy.
        /// </summary>
        private static void TablePerTypeWithTPH()
        {
            var db = new MediaTPTTBH();
            //articles
            var blogposting = new BlogPosting { Title = "Asp.net MVC", Author = "Scott", Post = "mvc content", TotalComments = 50 };
            var story = new Story { Title = "Alice In Wonderland", Author = "Charles", Plot = "story", IsFictious = true };

            //videos
            var educvideo = new EducationalVideo { Instructor = "Zee", ResourcePath = "Asp.netintro.wmv", Title = "Asp.net Video" };
            var recreatioanlvid = new RecreationalVideo { Title = "WorldCup", Rating = 5, ResourcePath = "cricket.wmv" };

            db.AddToMedias(blogposting);
            db.AddToMedias(story);
            db.AddToMedias(educvideo);
            db.AddToMedias(recreatioanlvid);
            db.SaveChanges();

            var db2 = new MediaTPTTBH();
            //getting count of total medias using esql
            Console.WriteLine("Total Medias " + db2.Medias.Count());
            Console.WriteLine("Total Videos " + db2.Medias.OfType<Video>().Count());
            Console.WriteLine("Total Articles " + db2.Medias.OfType<Article>().Count());
            Console.WriteLine("Total blog postings " + db2.Medias.OfType<BlogPosting>().Count());

            var edvideoandstory = db.Medias.Where(m => m is EducationalVideo || m is Story);
            Console.WriteLine("Total Ed videos and stories " + edvideoandstory.Count());
        }
    }
}
