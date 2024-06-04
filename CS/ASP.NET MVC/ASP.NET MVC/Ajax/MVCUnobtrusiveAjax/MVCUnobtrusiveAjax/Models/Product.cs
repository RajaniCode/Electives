using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUnobtrusiveAjax.Models
{
    public class Product
    {
        public int ProductId;
        public string Name;
        public string Description;
        public decimal Price;
        public Category Category;
    }

    public enum Category
    {
        Car,
        Airplane,
        Bicycle,
        Motorcycle
    }
}