namespace EF6CodeFirstExistingSQLServer2014
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EF6CodeFirstExistingSQLServer2014Context : DbContext
    {
        public EF6CodeFirstExistingSQLServer2014Context()
            : base("name=EF6CodeFirstExistingSQLServer2014Context")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
