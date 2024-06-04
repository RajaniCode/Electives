using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DialogDemo.Models
{
    public class HomeViewModel
    {
        public Person person { get; set; }
        public List<Book> cart { get; set; }
    }
}