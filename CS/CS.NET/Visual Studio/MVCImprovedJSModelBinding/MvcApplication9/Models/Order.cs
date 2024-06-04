using System;
using System.Collections.Generic;

namespace MvcApplication9.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime DateOrdered { get; set; }
        public int Quantity { get; set; }

        public static List<Order> GetOrders()
        {
            return new List<Order>
                       {
                           new Order { Id = 1, GivenName = "John", Surname = "Smith", Address = "100 Tom Street", DateOrdered = DateTime.Now.AddDays(-2), Quantity = 3 },
                           new Order { Id = 2, GivenName = "Steve", Surname = "Hllo", Address = "777 Hello Lane", DateOrdered = DateTime.Now.AddDays(-7), Quantity = 15 },
                           new Order { Id = 3, GivenName = "Kevin", Surname = "Rudd", Address = "666 Lane", DateOrdered = DateTime.Now.AddDays(12), Quantity = 8 }
                       };
        }
    }
}