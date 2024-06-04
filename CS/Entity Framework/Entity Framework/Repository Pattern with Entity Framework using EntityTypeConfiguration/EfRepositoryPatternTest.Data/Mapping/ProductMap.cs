using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using EfRepPatTest.Entity;

namespace EfRepPatTest.Data.Mapping
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //CategoryId as foreign key
            HasRequired(p => p.Category)
                .WithMany(c=>c.Products)
                .HasForeignKey(p => p.CategoryId);
            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.MinimumStockLevel);
        }
    }
}
