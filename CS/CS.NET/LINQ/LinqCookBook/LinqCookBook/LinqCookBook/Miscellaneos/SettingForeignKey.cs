using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Data.Extensions;
using System.Data;

using NorthWind.Business.EF.OneToMany;

namespace LinqCookBook.Miscellaneos
{
    public class SettingForeignKey
    {
        static void CleanUp()
        {
            var db = new OneToManyEntities();
            var cmd = db.CreateStoreCommand("delete onetomany.[Address] where Address1 ='Oakumber st';");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static void Run()
        {
            CleanUp();
            //Example1();
            SettingForeignKeyExample1.Run();
        }
        
        private static void Example1()
        {
            var db = new OneToManyEntities();
            var address = new Address { Address1 = "Oakumber st", City = "Dallas", State = "Tx", Zip = "76111" };
            address.CustomerReference.EntityKey = new EntityKey("OneToManyEntities.Customer","CustomerId",2);
            db.AddToAddresses(address);
            db.SaveChanges();
            
        }
    }
}
