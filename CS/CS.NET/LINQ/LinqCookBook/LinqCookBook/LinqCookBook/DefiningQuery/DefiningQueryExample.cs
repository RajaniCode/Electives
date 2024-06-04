using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.Extensions;
using NorthWind.Business.EF.DefiningQuery;

namespace LinqCookBook.DefiningQuery
{
    public class DefiningQueryExample
    {
        static void CleanUp()
        {
            var db = new DQForeignEntities();
            var cmd = db.CreateStoreCommand("delete tpt.GunClubs;delete tpt.ShootingRange;delete tpt.GunShows;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }

        public static void Run()
        {
            CleanUp();
            Example1();
        }

        private static void Example1()
        {
            var db = new DQForeignEntities();
            var gunclub = new GunClub { ClubName = "Club1", President = "Zee" };
            var shootingrange = new ShootingRange { RangeName = "Range1", Fees = 50 };
            db.AddToShootingRanges(shootingrange);
            db.AddToGunClubs(gunclub);
            var gunshow = new GunShow
            {
                ShowName = "GunShow",
                VendorsRegistered = 20,
                GunClub = gunclub
            };
            db.AddToGunShows(gunshow);
            db.SaveChanges();

            var db2 = new DQForeignEntities();
            var show = db2.GunShows.Include("GunClub").First(s => s.ShowName == "GunShow");
            Console.WriteLine("Show {0} Promoter {1}",show.ShowName,show.GunClub.ClubName);
        }
    }
}
