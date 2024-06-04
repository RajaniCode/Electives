using System.Collections.Generic;
using System.Linq;

namespace WebApplication1
{
    public class Employee
    {
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }

        public List<Employee> FetchEmployees()
        {
            return new List<Employee>
                       {
                           new Employee {Id = 1, GivenName = "Tom", Surname = "Hanks"},
                           new Employee {Id = 2, GivenName = "Tiger", Surname = "Woods"},
                           new Employee {Id = 3, GivenName = "Pat", Surname = "Cash"}
                       };
        }

        public Employee FetchEmployee(int id)
        {
            var employees = FetchEmployees();
            return (from p in employees
                    where p.Id == id
                    select p).First();
        }
    }
}
