using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.Inheritance;
using Microsoft.Data.Extensions;

namespace LinqCookBook.Inheritance
{
    public class TablePerConcreteType
    {
        static void CleanUp()
        {
            var db = new TPCEntities();
            var cmd = db.CreateStoreCommand("delete Company;delete School;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
            var db = new TPCEntities();
            var company = new Company { CompanyName = "Motels Ltd", Address = "123", President = "Zee" };
            var school = new School { Address = "123", Principal = "Alex", SchoolName = "Habib" };
            db.AddToLocations(company);
            db.AddToLocations(school);
            db.SaveChanges();

            //retrieve
            var db2 = new TPCEntities();
            var company2 = db.Locations.OfType<Company>().First();
            var school2 = db.Locations.OfType<School>().First();

            Console.WriteLine("Company Name " + company2.CompanyName);
            Console.WriteLine("School Name " + school2.SchoolName);
        }
    }
}
