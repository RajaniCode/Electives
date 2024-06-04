using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExampleCodeFirstApproch.Models
{
    public class LibraryContext :DbContext
    {
        public LibraryContext()
            : base("name=DbConnectionString")
        {
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            
            modelBuilder.Entity<Publisher>().HasKey(p => p.PublisherId);
            modelBuilder.Entity<Publisher>().Property(c => c.PublisherId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<Book>().HasKey(b => b.BookId);
            modelBuilder.Entity<Book>().Property(b => b.BookId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            
            modelBuilder.Entity<Book>().HasRequired(p => p.Publisher)
                .WithMany(b => b.Books).HasForeignKey(b=>b.PublisherId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}