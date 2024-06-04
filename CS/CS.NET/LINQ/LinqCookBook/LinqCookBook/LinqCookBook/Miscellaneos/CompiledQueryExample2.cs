using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoTPT;
using Microsoft.Data.Extensions;
using System.Data.Objects;
using NWComplexTypeModel;

namespace LinqCookBook.Miscellaneos
{
    class CompiledQueryExample2
    {
        static void CleanUp()
        {
            var db = new TwoTPTEntities();
            var cmd = db.CreateStoreCommand("delete tpt.Location;delete tpt.Company;delete tpt.Contact;delete tpt.GunSmith;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void ComplexType()
        {
            var entities = new NWComplexTypeEntities();
            var addresses = CompiledQuery.Compile<NWComplexTypeEntities, IQueryable<CommonAddress>>(
                            (db) => db.Customers.Where(c => c.Address.City == "London").Select(c => c.Address));
            foreach (var addr in addresses(entities))
            {
                Console.WriteLine(addr.Address);
            }
        }
        public static void BuildingAdditionalQueryOnCompiledQuery()
        {
            CleanUp();
            InsertGunSmith();
            var entities = new TwoTPTEntities();

            var gunsmiths = CompiledQuery.Compile<TwoTPTEntities, IQueryable<GunSmith>>(
                (db) => db.Contact.OfType<GunSmith>()
                      .Where(g => g.Company.CompanyName == "Widgets"));
            var smiths = gunsmiths(entities).Where(g => g.IsCertified == true);
            foreach (var smith in smiths)
	        {
        		 Console.WriteLine(smith.ContactName);
	        }

           
        }

        private static void InsertGunSmith()
        {
            var db = new TwoTPTEntities();
            var company = new Company { Address = "123 Happy St", CompanyName = "Widgets", Phone = "918-998-9956" };
            var gunsmith = new GunSmith
            {
                ContactName = "Zeeshan",
                Email = "abc@gmail.com",
                IsCertified = true,
                Company = company
            };
            var gunsmith2 = new GunSmith
            {
                ContactName = "John",
                Email = "abc@gmail.com",
                IsCertified = false,
                Company = company
            };
            db.AddToContact(gunsmith);
            db.SaveChanges();
        }
    }
}
