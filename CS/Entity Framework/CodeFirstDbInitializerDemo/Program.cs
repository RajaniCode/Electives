using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace CodeFirstDbInitializerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new BlogContextCustomInitializer());

            using (var db = new BlogContext())
            {
                Guid postId = Guid.NewGuid();
                Guid catId = Guid.NewGuid();
                var cat = new Category { Id = catId, Name = "ASP.NET" };
                var post = new BlogPost { Id = postId, Title = "Title1", Content = "Hello World!", PublishDate = new DateTime(2011, 1, 1), Category = cat };
                db.Categories.Add(cat);
                db.BlogPosts.Add(post);
                Console.WriteLine(db.Database.Connection.ConnectionString);
                int i = db.SaveChanges();
                Console.WriteLine("{0} records added...", i);
            }
            Console.ReadLine();
        }
    }

    [Table("BlogPosts")]
    public class BlogPost
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }

    [Table("Categories")]
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }

    public class BlogContext : DbContext
    {
        public BlogContext(): base()
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    public class BlogContextSeedInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            Category cat1 = new Category { Id = Guid.NewGuid(), Name = ".NET Framework" };
            Category cat2 = new Category { Id = Guid.NewGuid(), Name = "SQL Server" };
            Category cat3 = new Category { Id = Guid.NewGuid(), Name = "jQuery" };

            context.Categories.Add(cat1);
            context.Categories.Add(cat2);
            context.Categories.Add(cat3);

            context.SaveChanges();

        }
    }

    public class BlogContextCustomInitializer : IDatabaseInitializer<BlogContext>
    {

        public void InitializeDatabase(BlogContext context)
        {
            string sql = "CREATE TABLE GLOBAL_DATA([KEY] VARCHAR(50), [VALUE] VARCHAR(250))";
            if (context.Database.Exists() && context.Database.CompatibleWithModel(true))
            {
                return;
            }
            else
            {
                context.Database.Delete();
                context.Database.Create();
                context.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}
