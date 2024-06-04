using System.Collections.Generic;
using System.Linq;

namespace MvcApplication1.Models
{
    public partial class Employee
    {
        public int ID { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }

        public List<Employee> FetchEmployees()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee() { ID = 1, GivenName = "Malcolm", Surname = "Sheridan"  });
            employees.Add(new Employee() { ID = 2, GivenName = "Suprotim", Surname = "Agarwal" });
            return employees;
        }

        public Employee FetchEmployee(int id)
        {
            var employees = FetchEmployees();
            return (from p in employees
                           where p.ID == id
                           select p).First();    
        }
    }
}
