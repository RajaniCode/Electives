using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DialogDemo.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int CustomerID { get; set; }  
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }
        public string Price { get; set; }
    }
}