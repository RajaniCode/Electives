using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.Inheritance;
using Microsoft.Data.Extensions;

namespace LinqCookBook.Inheritance
{
    public static class TablePerType
    {
        static void CleanUp()
        {
            var db = new STPTInh();
            var cmd = db.CreateStoreCommand("delete Videos;delete Articles;delete Medias;delete TBH.Employees;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

        }
        public static void Run()
        {
            CleanUp();
            //TablePerTypeWalkThrough();
            //TablePerHiearachy();
            
        }
       

        private static void TablePerHiearachy()
        {
            var db = new STPTInh();
            var hourly = new HourlyEmployee { Name = "Alex", Rate = 40, Hours = 40 };
            var salaried = new SalariedEmployee { Name = "Chris", Salary = 90000 };
            db.AddToEmployees(hourly);
            db.AddToEmployees(salaried);
            db.SaveChanges();
            var db2 = new STPTInh();
            var huorly1 = db2.Employees.OfType<HourlyEmployee>().First();
            Console.WriteLine("Name {0} Rate {1} Hours {2}",huorly1.Name,huorly1.Rate,huorly1.Hours);

            var salary1 = db2.Employees.OfType<SalariedEmployee>().First();
            Console.WriteLine("Name {0} Salary {1}",salary1.Name,salary1.Salary);

            
        }

        private static void TablePerTypeWalkThrough()
        {
            var db = new STPTInh();
            //inserting article and videos
            Article article = new Article
            {
                Title = "Linq Getting Started",
                ArticleContent = "article content"
            };

            Video video = new Video
            {
                Title = "Bill Wagner with More on C# 3.0",
                ResourcePath = "CsharpwithBill.wmv"
            };
            db.AddToMedias(article);
            db.AddToMedias(video);
            db.SaveChanges();

            var db2 = new STPTInh();
            //get articles
            var articles = db2.Medias.OfType<Article>();
            foreach (var art in articles)
            {
                Console.WriteLine("Title {0} Content{1}", art.Title, art.ArticleContent);
            }

            var vidoes = db.Medias.Where(m => m is Video).ToList().Cast<Video>();
            foreach (var vid in vidoes)
            {
                Console.WriteLine("Title {0} Resource {1}", vid.Title, vid.ResourcePath);
            }
        }
    }
}
