using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.Inheritance;
using Microsoft.Data.Extensions;
using InhQVLocationModel;

namespace LinqCookBook.Inheritance
{
    public class InheritanceWithQueryView
    {
        static void CleanUp()
        {
            var db = new InhQVLocation();
            var cmd = db.CreateStoreCommand(" delete TBH.Articles;delete TBH.Videos;delete TBH.Medias;delete EventLocation;delete GunClubs;delete ShootingRange;delete Locations;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
            TablePerTypeWithQueryView();
           // TestingQueryViewForOptimization();
        }

        private static void TestingQueryViewForOptimization()
        {
            var db = new InhQVLocation();
            string sql;
            sql = db.Locations.OfType<EventLocation>().ToTraceString();
            Console.WriteLine(sql);
            db.Locations.OfType<Organization>().ToList();
            
        }

        private static void TablePerTypeWithQueryView()
        {
            var db = new InhQVLocation();
            var evlocation = new EventLocation { LocationName = "Abba Shrine Center", Address = "7701 Hitt Road" };
            var club1 = new GunClub { ClubName = "Cambria Hunting Club", Address = "240 Woodstream Dr" };
            var club2 = new GunClub { ClubName = "Head Hunter Gun Club", Address = "680 Porterville Rd" };
            var range = new ShootingRange { RangeName = "Cooper Range", Address = "Bean Creek Road" };
            db.AddToLocations(evlocation);
            db.AddToLocations(club1);
            db.AddToLocations(club2);
            db.AddToLocations(range);
            db.SaveChanges();
            var db2 = new InhQVLocation();
            Console.WriteLine("Total Locations {0}", db2.Locations.Count());
            Console.WriteLine("Event Locations {0}", db2.Locations.OfType<EventLocation>().Count());
            Console.WriteLine("Total Organizations {0}", db2.Locations.OfType<Organization>().Count());
            Console.WriteLine("Total Ranges {0}", db2.Locations.OfType<ShootingRange>().Count());
            Console.WriteLine("Total GunClubs {0}", db2.Locations.OfType<GunClub>().Count());
        }
    }
}
