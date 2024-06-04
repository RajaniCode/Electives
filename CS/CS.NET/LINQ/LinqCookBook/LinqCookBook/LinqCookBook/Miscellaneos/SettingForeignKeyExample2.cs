using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Data.Extensions;
using System.Data;
using NorthWind.Business.EF.AdventureWorksLT;

using MM;

namespace LinqCookBook.Miscellaneos
{
    public class SettingForeignKeyExample1
    {
        static void CleanUp()
        {
            var db = new AdventureWorksLTEntities();
            var cmd = db.CreateStoreCommand("update SalesLT.Product set ProductModelID = 6 where ProductNumber = 'FR-R92B-58';delete SalesLT.Product where ProductNumber='FR-R92B-59';");
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public static void Run()
        {
            CleanUp();
            //SimpleAssignment();
            //UsingParitalclass();
            //ManyToManyMapping();
            //RemovingEntityReference();
            ReferenceGetAffectedAsWell();
            //IncorrectUsage();
        }

        private static void ReferenceGetAffectedAsWell()
        {
            InsertProduct();
            var db = new AdventureWorksLTEntities();
            var prod = db.Product.Include("ProductModel").First(p => p.ProductNumber == "FR-R92B-59");
            Console.WriteLine("Model:{0}",prod.ProductModel.ProductModelID);
            //set entitykey for model to null also removes the reference.
            prod.ProductModelReference.EntityKey = null;
            Console.WriteLine("ProductModel clr object is {0}", prod.ProductModel == null ? "null" : "not null");
        }

        private static void RemovingEntityReference()
        {
            InsertProduct();
             var db = new AdventureWorksLTEntities();
            var prod = db.Product.First(p => p.ProductNumber == "FR-R92B-59");
            Console.WriteLine("Model:{0}", prod.ProductModelReference.EntityKey.EntityKeyValues[0].Value);
            
            prod.ProductModelReference.EntityKey = null;
            db.SaveChanges();
        }

        private static void InsertProduct()
        {
            var db = new AdventureWorksLTEntities();
            var prod = db.Product.FirstOrDefault(p => p.ProductNumber ==  "FR-R92B-59");
            if (prod == null)
            {
                var cmd = db.CreateStoreCommand(@"insert into SalesLT.Product(Name,ProductNumber,ModifiedDate,StandardCost,ListPrice,SellStartDate,ProductModelID)
values ('Bike','FR-R92B-59',GETDATE(),5.0,5.0,GETDATE(),2)");
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

        }

        private static void SimpleAssignment()
        {
            var db = new AdventureWorksLTEntities();
            var prod = db.Product.First(p => p.ProductNumber == "FR-R92B-58");
            var productmodel = db.ProductModel.First(m => m.ProductModelID == 2);
            prod.ProductModel = productmodel;
            db.SaveChanges();
        }

        private static void ManyToManyMapping()
        {
            InsertStudent();
            var db = new MMStudentCoursesEntities();
            var student = db.Students.First(s => s.Name == "Harold");
            var course = new Course { CourseId = 1 };
            db.AttachTo("Courses",course);
            student.Courses.Add(course);
            db.SaveChanges();
            
        }

        private static void InsertStudent()
        {
            var db = new MMStudentCoursesEntities();
            if (db.Students.FirstOrDefault(s => s.Name == "Harold") == null)
            {
                var student = new Student { Name = "Harold" };
                db.AddToStudents(student);
                db.SaveChanges();    
            }
        }

      
        private static void UsingParitalclass()
        {
            var db = new AdventureWorksLTEntities();
            var prod = db.Product.First(p => p.ProductNumber == "FR-R92B-58");
            prod.ModelId = 2;
            db.SaveChanges();
        }

        private static void IncorrectUsage()
        {
            var db = new AdventureWorksLTEntities();
            var prod = db.Product.First(p => p.ProductNumber == "FR-R92B-58");
            //Error:entity key value cannot be changed once they are set.
            prod.ProductModelReference.EntityKey.EntityKeyValues[0].Value = 2;
            db.SaveChanges();
        }

    }
}
