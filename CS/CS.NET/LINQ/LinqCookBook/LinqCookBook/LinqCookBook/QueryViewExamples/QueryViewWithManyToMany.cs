using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.QueryView;
using  Microsoft.Data.Extensions;
using QueryViewWithManyToMany;

namespace LinqCookBook.QueryViewExamples
{
    public static class QueryViewWithManyToMany
    {
        public static void Run()
        {
            CleanUp();
            QueryViewWithManyToManyMapping();
        }

        private static void CleanUp()
        {
            var db = new QueryViewMM();
            var cmd = db.CreateStoreCommand("delete QueryView.Membership;delete QueryView.Clubs;delete QueryView.Members");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        private static void QueryViewWithManyToManyMapping()
        {
            var db = new QueryViewMM();
            var club = new Club
            {
                ClubName = "Football Club",
                GoldMembers = {
                                new Member{Name = "Scott"},
                                new Member{Name = "Allen"}
                             },
                PlatiniumMembers = { new Member { Name = "Chris" } }
            };
            db.AddToClubs(club);
            db.SaveChanges();

            var db2 = new QueryViewMM();
            var footballclub = db2.Clubs
                                 .Include("PlatiniumMembers").Include("GoldMembers")
                                 .First(c => c.ClubName == "Football Club");

            Console.WriteLine("Club Name " + footballclub.ClubName);
            Console.WriteLine("Gold Club Members");
            foreach (var member in footballclub.GoldMembers)
            {
                Console.WriteLine(member.Name);
            }
            Console.WriteLine("Platinium Members");
            foreach (var member in footballclub.PlatiniumMembers)
            {
                Console.WriteLine(member.Name);
            }
        }

    }
}
