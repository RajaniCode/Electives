using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthWind.Business.LS.TablePerHiearachy;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ConsoleLinqToSql.TablePerHiearachy
{
    class TablePerHiearachyExample
    {
        public static void BooksExample()
        {
            var db = new TPHDataContext();
            //insert different books
            var books = new Book[]
            {
               new TecnnicalBook{Title="Programming WCF",Technology="Microsoft"},
               new CertificationBook{Title="Sql server Training",Technology="Microsoft",Exam="70-431"},
               new CookingBook{Title="Cooks Special",ReceipesAvailable=true},
               new Novel{Title="Journey To Moon",TrueStory=false}
            };
            db.Books.InsertAllOnSubmit(books);
            db.SubmitChanges();

            Console.WriteLine("All Books");
            foreach (var book in db.Books)
	        {
                Console.WriteLine(book.Title ); 
	        }

            Console.WriteLine("\r\nCertification Book With Derived class reference");
            var certbook = db.Books.OfType<CertificationBook>().First();
            Console.WriteLine("Author {0} Technology {1} Exam {2}",certbook.Title,certbook.Technology,certbook.Exam);

            Console.WriteLine("\r\nNovel with base class reference");
            var novel = db.Books.First(b => b is Novel);
            Console.WriteLine("Author {1} TrueStory {1}",novel.Title,((Novel)novel).TrueStory);

            var db1 = new DataContext("connectionstring", XmlMappingSource.FromUrl("Books.mapping"));

        }
    }
}
