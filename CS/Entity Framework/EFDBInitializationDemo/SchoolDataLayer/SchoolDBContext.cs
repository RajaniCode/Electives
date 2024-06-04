using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SchoolDomainClasses;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SchoolDataLayer
{
    public class SchoolDBContext: DbContext 
    {
        // Pass database name you want to create in constructor or Pass connection string name if you want to set location and DB name from connection string
        // If nothing is passed in base constructor then it will create database with Namespacename.classname eg. "SchoolDataLayer.Context" in SQLExpress
        public SchoolDBContext()
            : base("SchoolDBConnectionString") //: base("SchoolDBCodeFirst") 
        {
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new CreateDatabaseIfNotExists<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new  SchoolDBInitializer());
            

            //Disable initializer
            Database.SetInitializer<SchoolDBContext>(null);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }

    }
}
