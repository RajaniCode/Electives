using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstNewDatabase2010
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BloggingContext>());
            using (var db = new BloggingContext())
            {
                Console.Write("Enter a new Blog Name: ");
                var name = Console.ReadLine();

                var blg = new Blog { Name = name };
                db.Blogs.Add(blg);
                db.SaveChanges();

                var query = from blgs in db.Blogs
                            orderby blgs.Name
                            select blgs;

                Console.WriteLine("All Blog Names:");

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit . . .");
                Console.ReadKey();
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class User
    {
        [Key]
        public int Username { get; set; }

        public string DisplayName { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("display_name");
        }
    }
}
