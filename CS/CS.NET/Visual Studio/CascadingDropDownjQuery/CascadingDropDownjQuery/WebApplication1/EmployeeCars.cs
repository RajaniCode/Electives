using System.Collections.Generic;
using System.Linq;

namespace WebApplication1
{
    public class EmployeeCar
    {
        public int Id { get; set; }
        public string Car { get; set; }

        private static List<EmployeeCar> LoadData()
        {
            return new List<EmployeeCar>
                       {
                           new EmployeeCar {Id = 1, Car = "Ford"},
                           new EmployeeCar {Id = 1, Car = "Holden"},
                           new EmployeeCar {Id = 1, Car = "Honda"},
                           new EmployeeCar {Id = 2, Car = "Toyota"},
                           new EmployeeCar {Id = 2, Car = "General Motors"},
                           new EmployeeCar {Id = 2, Car = "Volvo"},
                           new EmployeeCar {Id = 3, Car = "Ferrari"},
                           new EmployeeCar {Id = 3, Car = "Porsche"},
                           new EmployeeCar {Id = 3, Car = "Ford"}
                       };
        }

        public List<EmployeeCar> FetchEmployeeCars(int id)
        {
            return (from p in LoadData()
                    where p.Id == id
                    select p).ToList();
        }
    }
}
