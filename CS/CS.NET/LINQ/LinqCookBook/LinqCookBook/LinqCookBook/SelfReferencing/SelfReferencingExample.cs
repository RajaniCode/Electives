using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.SelfReferencing;

namespace LinqCookBook.SelfReferencing
{
    public static class SelfReferencingExample
    {

        public static void Run()
        {
            //Example1();
            Example2();
        }

        private static void Example2()
        {
            var db = new MediaSelfRefEntities();
            //first level media and second level media as well.
            var cats = from cat in db.MediaCategories.Include("SubCategories.Medias").Include("Medias")
                       where cat.SubCategories.Count() > 0 || cat.Medias.Count() > 0
                       select cat;
            foreach (var cat in cats)
            {
                Console.WriteLine("Name:{0} SubCategories:{1} Medias:{2}",
                    cat.Name,cat.SubCategories.Count(),cat.Medias.Count());
                foreach (var subcat in cat.SubCategories)
                {
                    Console.WriteLine("\tName:{0} SubCategories:{1} Medias:{2}",
                    subcat.Name,subcat.SubCategories.Count(),subcat.Medias.Count());
                }
            }
        }

        private static void Example1()
        {
            var db = new MediaSelfRefEntities();
            var cats = from cat in db.MediaCategories.Include("Medias")
                       where cat.Category == null /* parent category is null */
                       && cat.Medias.Count() > 0
                       select cat;

            foreach (var cat in cats)
            {
                Console.WriteLine("Name:{0}  Articles:{1}   Videos:{2}",
                    cat.Name,
                    cat.Medias.OfType<Article>().Count(),cat.Medias.OfType<Video>().Count());
            }
        }
    }
}
