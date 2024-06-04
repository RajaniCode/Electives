using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.Miscellaneos;
using Microsoft.Data.Extensions;

namespace LinqCookBook.Miscellaneos
{
    public class DelayLoading
    {
        public static void Run()
        {
            CleanUp();
            InsertArticle();
            //Example1();
            Exmaple2();
        }

        private static void Exmaple2()
        {
            var db = new DelayLoadingEntities();
            foreach (var article in db.Articles.Include("ArticleDetail"))
            {
                Console.WriteLine("Title:{0} Publish Date:{1} Content:{2}", 
                    article.Title, article.PublishedDate.ToString("d"),article.ArticleDetail.Content);
            }
        }

        private static void Example1()
        {
            var db = new DelayLoadingEntities();
            foreach (var article in db.Articles)
            {
                Console.WriteLine("Title:{0} Publish Date:{1}", article.Title, article.PublishedDate.ToString("d"));
            }
        }

        private static void InsertArticle()
        {
            var db = new DelayLoadingEntities();
            var article = new Article
            {
                PublishedDate = DateTime.Today,
                Title = "Entity Framework Recipes",
                ArticleDetail = new ArticleDetail 
                { 
                    AuthorInfo = "author descriptio", Summary = "article summary", Content = "article content" 
                }
            };
            db.AddToArticles(article);
            db.SaveChanges();
        }

        private static void CleanUp()
        {
            var db = new DelayLoadingEntities();
            var cmd = db.CreateStoreCommand("delete rs.Article;");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
