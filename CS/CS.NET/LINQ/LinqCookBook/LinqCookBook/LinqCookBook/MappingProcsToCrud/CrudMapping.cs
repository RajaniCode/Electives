using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.EF.MappingProcToCrud;
using SpMappComplexType;
using Microsoft.Data.Extensions;
using NorthWind.Business.EF.MappingProcToCrud.Concurrency;
using System.Data;
namespace LinqCookBook.MappingProcsToCrud
{
    public class CrudMapping
    {
        static void CleanUp()
        {
            var db = new StoredProcMappingEntities();
            var cat1 = db.Categories.FirstOrDefault(c => c.CategoryName == "HomeStyle Foo");
            if (cat1 != null)
            {
                db.DeleteObject(cat1);    
            }
            var addinfo = db.ProductAdditionalInfo.FirstOrDefault();
            if (addinfo != null)
            {
                db.DeleteObject(addinfo);    
            }
            var prod = db.Products.FirstOrDefault(p => p.ProductName == "Hair Formula");
            if (prod != null)
            {
                db.DeleteObject(prod);    
            }
            var supp = db.Suppliers.FirstOrDefault(s => s.CompanyName == "Hairs LTD");
            if (supp != null)
	        {
		         db.DeleteObject(supp);
	        }

            var cat2 = db.Categories.FirstOrDefault(c => c.CategoryName == "Makeups");
            if (cat2 != null)
            {
                db.DeleteObject(cat2);    
            }
            db.SponsorSet.ToList().ForEach(s => db.DeleteObject(s));
            db.MusicalShow.ToList().ForEach(s => db.DeleteObject(s));

            var cmd = db.CreateStoreCommand("truncate table SPIH.people;truncate table authors");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            db.SaveChanges();
            var sdb = new SpMappComplex();
            var cust1 = sdb.Customers.FirstOrDefault(c => c.CustomerID == "ALFK1");
            if (cust1 != null)
            {
                sdb.DeleteObject(cust1);
                sdb.SaveChanges();    
            }
        }

        public static void Run()
        {
            CleanUp();
            //CategoryProcMapping();
            //PRoductProcMapping();
            //ManyToManyStoredProcedure();
            //StoredProcMappingToComplexType();
            //MappingToInheritance();
            StoredProcedureConcurrency();
        }

        private static void StoredProcMappingToComplexType()
        {
            var db = new SpMappComplex();
            var customer = new Customers
            {
                CustomerID = "ALFK1",
                ContactName = "Zeeshan Hirani",
                Address = new CAddress { City = "Dallas", StreetAddress = "123 Address", Zip = "76111" }
            };
            db.AddToCustomers(customer);
            db.SaveChanges();
            db.DeleteObject(customer);
            db.SaveChanges();
        }
        private static void ManyToManyStoredProcedure()
        {
            var db = new StoredProcMappingEntities();
            var alex = new Sponsor{Name="Alex Jones"};
            var mark = new Sponsor{Name="Mark Walt"};
            var musicalshow = new
            MusicalShow
            {
                ShowName = "Rock Concert",
                Sponsors = {alex,mark}
            };
            var rockandroll = new MusicalShow
            {
                ShowName = "Rock And Roll",
                Sponsors = { alex }
            };

            //causes insert to sponsor table and the show_sponsor link table.
            db.AddToMusicalShow(musicalshow);
            db.AddToMusicalShow(rockandroll);
            db.SaveChanges();
          
            //removes alex from the sponsor_show
            rockandroll.Sponsors.Remove(alex);

            //removes all sponsors from sponsor_show for musicalshow
            musicalshow.Sponsors.Clear();
            db.SaveChanges();




        }
        private static void PRoductProcMapping()
        {
            var db = new StoredProcMappingEntities();
            var cat = new Category { CategoryName = "Makeups" };

            var supplier = new Supplier { CompanyName = "Hairs LTD" };
            var product = new Product
            {
                ProductName = "Hair Formula",
                UnitPrice = 12.0M,
                Supplier = supplier,
                Category = cat,
                ProductAdditionalInfo =
                new ProductAdditionalInfo
                {
                    ProductDescription = "Hair Dye",
                    UnitsInStock = 20
                }
            };
            db.AddToProducts(product);
            db.SaveChanges();
            Console.WriteLine("Insert Details");
            Console.WriteLine("Cat ID: {0} Name:{1}",cat.CategoryID,cat.CategoryName);
            Console.WriteLine("Supp ID: {0} Name:{1}",supplier.SupplierID,supplier.CompanyName);
            Console.WriteLine("Prod ID:{0} Name:{1}",product.ProductID,product.ProductName);
            
            //update product info.
            var db2 = new StoredProcMappingEntities();
            var updateproduct = db2.Products.First(p => p.ProductName == "Hair Formula");
            //change the unit price price.
            updateproduct.UnitPrice = 15.0M;
            db2.SaveChanges();
            //change supplier and category information and product additional info.
            
            updateproduct.Supplier = db2.Suppliers.First(sp => sp.SupplierID == 1);
            
            updateproduct.Category = db2.Categories.FirstOrDefault(c => c.CategoryID == 1);
            updateproduct.ProductAdditionalInfoReference.Load();

            //load product additonal info.
            updateproduct.ProductAdditionalInfo.ProductDescription = "Hair formula";

            db2.SaveChanges();
          
            //delete updated product and additionalinfo table
            db2.DeleteObject(updateproduct);
            db2.SaveChanges();
        }
        private static void CategoryProcMapping()
        {
            var db = new StoredProcMappingEntities();
            var cat = new Category
            {
                CategoryName = "HomeStyle Food",
                Description = "Different homemade foods"
            };
            //calls InsertCategory stored proc
            db.AddToCategories(cat);
            db.SaveChanges();
            Console.WriteLine("Category inserted: {0}", cat.CategoryID);
            //calls UpdateCategory stored proc
            cat.Description = "HomeStyle Food delicious";
            db.SaveChanges();

            //calls delete stored proc.
            //db.DeleteObject(cat);
            //db.SaveChanges();
        }

        public static void MappingToInheritance()
        {
            var db = new SPInhMapping();
            var spstudent = new SpecialStudent
            {
                EnrollmentDate = DateTime.Now,
                Name = "James",
                SpecialNeeds = "Hearing"
            };
            var student = new Student
            {
                EnrollmentDate = DateTime.Now,
                Name = "Zeeshan Hirani"
            };
            var employee = new Employee
            {
                HireDate = DateTime.Now,
                Name = "Alex"
            };
            db.AddToPersons(spstudent);
            db.AddToPersons(student);
            db.AddToPersons(employee);
            db.SaveChanges();
        }

        public static void StoredProcedureConcurrency()
        {
            var db = new SpConcurrency();
            var author = new Author{Name = "Zeeshan",BooksPublished = 1};
            db.AddToAuthors(author);
            db.SaveChanges();
            Console.WriteLine("authorid {0} timestamp {1}",author.AuthorId,
                Convert.ToBase64String(author.TimeStamp));
            //cause concurrency voilation
            db.Connection.Open();
            db.CreateStoreCommand("update authors set BooksPublished = 2 where name = 'Zeeshan'")
               .ExecuteNonQuery();
            db.Connection.Close();
            author.Name = "Zeeshan Hirani";
            try
            {
               int result = db.SaveChanges();
            }
            catch (OptimisticConcurrencyException ex)
            {

                Console.WriteLine("Concurreny voilation on update " + ex.Message);
            }
            
            //update fails but let's try deleting the object.
            db.DeleteObject(author);
            try
            {
                db.SaveChanges();
            }
            catch (OptimisticConcurrencyException ex)
            {
                //delete also fails because of optimistic concurrency.
                Console.WriteLine("Concurreny voilation on delete " + ex.Message);
                db.Detach(author);
                db.Attach(author);
            }
            //get a fresh copy from the database
            db.Refresh(System.Data.Objects.RefreshMode.ClientWins, author);
            author.Name = "Zeeshan Hirani";
            //update author name succeeds
            db.SaveChanges();
            //delete to author succeeds.
            db.DeleteObject(author);
            db.SaveChanges();
            Console.WriteLine("Author delete successfully");
            
        }
    }
}
