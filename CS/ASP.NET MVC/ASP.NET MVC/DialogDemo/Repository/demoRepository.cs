using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using DialogDemo.Models;

namespace DialogDemo.Repository
{
    public class demoRepository
    {
        public Person GetPerson(int id)
        {
            return new Person { PersonId = 1, FirstName = "Tom", LastName = "Jones" };
        }

        public Person SelectPerson(int personID)
        {
            string fullXmlPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/customers.xml");
            XElement doc = XElement.Load(fullXmlPath);
            string id = personID.ToString();
            var result = (from p in doc.Elements("customer")
                          where p.Element("personID").Value == id
                          select new Person
                          {
                              PersonId = Int32.Parse(p.Element("personID").Value),
                              FirstName = p.Element("firstName").Value,
                              LastName = p.Element("lastName").Value
                          }).ElementAtOrDefault(0);

            return null != result ? result : new Person();
        }

        public void UpdatePerson(Person personToUpdate)
        {
            string fullXmlPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/customers.xml");
            XDocument xdocument = XDocument.Load(fullXmlPath);
            XElement elem = xdocument.Element("customers");
            string id = personToUpdate.PersonId.ToString();

            var persondata = (from person in elem.Elements("customer")
                              where person.Element("personID").Value == id
                              select person).Single();


            persondata.Element("firstName").Value = personToUpdate.FirstName;
            persondata.Element("lastName").Value = personToUpdate.LastName;

            xdocument.Save(fullXmlPath);
        }

        public List<Book> SelectBooks(int customerID)
        {
            string fullXmlPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/books.xml");
            XDocument xdocument = XDocument.Load(fullXmlPath);
            XElement elem = xdocument.Element("purchases");

            string id = customerID.ToString();

            List<Book> books = (from customer in elem.Elements("customer")
                                from book in customer.Elements("book")
                                where customer.Attribute("id").Value == id
                         select new Book
                         {
                            CustomerID = customerID,
                            BookId = int.Parse(book.Attribute("id").Value),
                            Title = book.Element("title").Value,
                            Author = book.Element("author").Value,
                            PublicationYear = book.Element("pubDate").Value,
                            Price = book.Element("price").Value
                         }).ToList<Book>();

            return books;
        }

        public Book SelectBook(int bookid, int customerid)
        {
            string fullXmlPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/books.xml");
            XDocument xdocument = XDocument.Load(fullXmlPath);
            XElement elem = xdocument.Element("purchases");

            var result = (from customer in elem.Elements("customer")
                                from book in customer.Elements("book")
                                where customer.Attribute("id").Value == customerid.ToString()
                                where book.Attribute("id").Value == bookid.ToString()
                         select new Book
                         {  
                            CustomerID = customerid,
                            BookId = int.Parse(book.Attribute("id").Value),
                            Title = book.Element("title").Value,
                            Author = book.Element("author").Value,
                            PublicationYear = book.Element("pubDate").Value,
                            Price = book.Element("price").Value
                         }).ElementAtOrDefault(0);

            return null != result ? result : new Book();
            //return new Book();
        }

        public void UpdateBook(Book bookToUpdate)
        {
            string fullXmlPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/books.xml");
            XDocument xdocument = XDocument.Load(fullXmlPath);
            XElement elem = xdocument.Element("purchases");

            var bookData = (from customer in elem.Elements("customer")
                          from book in customer.Elements("book")
                          where customer.Attribute("id").Value == bookToUpdate.CustomerID.ToString()
                          where book.Attribute("id").Value == bookToUpdate.BookId.ToString()
                          select book).Single();

            bookData.Element("title").Value = bookToUpdate.Title;
            bookData.Element("author").Value = bookToUpdate.Author;
            bookData.Element("pubDate").Value = bookToUpdate.PublicationYear;
            bookData.Element("price").Value = bookToUpdate.Price;

            xdocument.Save(fullXmlPath);
        }


    }
}