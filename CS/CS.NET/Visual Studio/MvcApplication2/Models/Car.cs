using System.Collections.Generic;
namespace MvcApplication2.Models
{
    public class Car
    {
        public string Make { get; set; }
        public int Id { get; set; }

        public static List<Car> GetCars()
        {
            return new List<Car>
                           {
                               new Car { Id = 1, Make = "Ford"},
                               new Car { Id = 2, Make = "Holden"},
                               new Car { Id = 3, Make = "Chevrolet"}
                           };
        }
    }
}