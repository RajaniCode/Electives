using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.ManyToManyRelationship;
using  Microsoft.Data.Extensions;

namespace LinqCookBook.ManyToManyMapping
{
    public class ManyToManyExample
    {
        
        public static void Run()
        {
            CleanUp();
           // ReturningIds();
           // RelationShipSpan();
           // InsertingShows();
            //RetrieveingOnlyRelationShip();
            //ManyToManyRelationshipAsTwoOneToMany();
            //OneToManyAsManyToMany();
            ManyToManyAsTwoManyToMany();
        }

        private static void ManyToManyAsTwoManyToMany()
        {
            var db = new MultipleAssocationsEntities();
            var george = new Actors { Name = "George Clooney" };

            var Syriana = new Movies { Title = "Syriana" };
            var BabyTalk = new Movies { Title = "Baby Talk" };
            var Roseanne = new Movies { Title = "Roseanne" };

            db.AddToMovies(Syriana);
            db.AddToMovies(BabyTalk);
            db.AddToMovies(Roseanne);

            george.MoviesWithLeadingActor.Add(BabyTalk);
            george.MoviesWithLeadingActor.Add(Syriana);
            george.MoviesWithSupportingRole.Add(Roseanne);

            db.SaveChanges();

            //query using a different datacontext.
            var db1 = new MultipleAssocationsEntities();
            var george1 = db1.Actors.Include("MoviesWithLeadingActor").Include("MoviesWithSupportingRole").First(a => a.Name == "George Clooney");
            
            Console.WriteLine("Total Movies with Leading Role " + george1.MoviesWithLeadingActor.Count());
            Console.WriteLine("Total Movies with Supporing Role " + george.MoviesWithSupportingRole.Count());
        }

        private static void CleanUp()
        {
            var db = new MultipleAssocationsEntities();
            var cmd = db.CreateStoreCommand("delete Actors_Movies;delete Actors;delete Movies;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private static void OneToManyAsManyToMany()
        {
            var db = new ManyToManyEntities();
            var scott = db.Members.Include("Clubs").First(m => m.Name == "Scott");
            var mems = db.Members.Where(m => m.Clubs.Any(c => c.ClubName == "aa"));
            Console.WriteLine("Clubs for member {0}", scott.Name);
            foreach (var club in scott.Clubs)
            {
                Console.WriteLine(club.ClubName);
            }
        }

        private static void ManyToManyRelationshipAsTwoOneToMany()
        {
            var db = new ManyToManyEntities();
            var st = db.Students.Include("StudentCourse.Course").First(s => s.Name == "Zeeshan");
            Console.WriteLine("Courses for student {0}",st.Name);
            foreach (var stcourse in st.StudentCourse)
            {
                Console.WriteLine(stcourse.Course.CourseName);
            }
        }

        private static void RetrieveingOnlyRelationShip()
        {
            var db = new ManyToManyEntities();
            var showsponsor = from sponsor in db.Sponsors
                              from show in sponsor.MusicalShows
                              select new { show.ShowId, sponsor.SponsorId };
            Console.WriteLine(showsponsor.AsObjectQuery().ToTraceString());
            showsponsor.ToList().ForEach(
                sp => 
                    Console.WriteLine("ShowId {0} SponsorId {1}",sp.ShowId,sp.SponsorId));

            //using method syntax
            var showsp = db.Sponsors.
                            SelectMany(s => s.MusicalShows, 
                                    (sponsor, show) => new { sponsor.SponsorId, show.ShowId });
            Console.WriteLine(  "Using Method syntax");
            showsp.ToList().ForEach(
                sp =>
                    Console.WriteLine("ShowId {0} SponsorId {1}", sp.ShowId, sp.SponsorId));
        }

        private static void InsertingShows()
        {
            var db = new ManyToManyEntities();
            var show1 = new MusicalShow { ShowName = "Johnny and the Sprites" };
            var show2 = new MusicalShow { ShowName = "Sesame Street" };

            var miller = db.Sponsors.First(s => s.Name == "Miller Lite");
            //add show1 and show2 to miller
            miller.MusicalShows.Add(show1);
            miller.MusicalShows.Add(show2);

            db.SaveChanges();
            //to delete show relationship with miller 
            //sponsor simply remove it from collection
            miller.MusicalShows.Remove(show1);
            
            //deleting the show automatically removes the relationship
            //from the sponsor.
            db.DeleteObject(show2);
            db.SaveChanges();

        }



        private static void RelationShipSpan()
        {
            var db = new ManyToManyEntities();
            var miller = db.Sponsors.First(s => s.Name == "Miller Lite");
            var shows = (from show in db.MusicalShows
                        from sponsor in show.Sponsors
                        where sponsor.Name == "Miller Lite"
                        select show     
                        ).ToList();
            Console.WriteLine("using relationship span");
            Console.WriteLine("shows for miller sponsor " + miller.MusicalShows.Count());

        }

        
        private static void ReturningIds()
        {
             var db = new ManyToManyEntities();
             var miller = db.Sponsors.First(s => s.Name == "Miller Lite");
            //lazy load the miller 
             if (!miller.MusicalShows.IsLoaded)
             {
                 miller.MusicalShows.Load();
             }
            Console.WriteLine("Lazy Loading");
             Console.WriteLine("Shows for miller lite " + miller.MusicalShows.Count());

            //eager loading
             var db2 = new ManyToManyEntities();
             var miller2 = db2.Sponsors.Include("MusicalShows").First(s => s.Name == "Miller Lite");

             Console.WriteLine("Eager Loading");
             Console.WriteLine("Shows for miller lite " + miller2.MusicalShows.Count());

        }
    }
}
