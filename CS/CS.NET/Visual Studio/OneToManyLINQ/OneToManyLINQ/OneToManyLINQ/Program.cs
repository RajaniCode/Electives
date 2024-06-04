using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneToManyLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> lists = new List<Department>() 
            { 
                new Department() 
                { 
                    DeptID = 1, DeptName = "Marketing", employee = new List<Employee>
                    { 
                        new Employee() { EmpID = 9, DeptID = 1, Name = "Jack Nolas", AgeInYrs = 28 }, 
                        new Employee() { EmpID = 5, DeptID = 1, Name = "Mark Pine" , AgeInYrs = 42 }, 
                        new Employee() { EmpID = 3, DeptID = 1, Name = "Sandra Simte" , AgeInYrs = 38 },
                        new Employee() { EmpID = 8, DeptID = 1, Name = "Larry Lo" , AgeInYrs = 31 }
                    } 
                }, 
                new Department() 
                {
                    DeptID = 2, DeptName = "Sales", employee = new List<Employee> 
                    {
                        new Employee() { EmpID = 1, DeptID = 2, Name = "Sudhir Panj" , AgeInYrs = 28 }, 
                        new Employee() { EmpID = 7, DeptID = 2, Name = "Kathy Karlo" , AgeInYrs = 43 },
                        new Employee() { EmpID = 4, DeptID = 2, Name = "Dinesh Kumar" , AgeInYrs = 34 } 
                    } 
                },
                new Department() 
                {
                    DeptID = 3, DeptName = "HR", employee = new List<Employee>
                    {
                        new Employee() { EmpID = 2, DeptID = 3, Name = "Kaff Joe" , AgeInYrs = 25 }, 
                        new Employee() { EmpID = 6, DeptID = 3, Name = "Su Lie" , AgeInYrs = 52 },
                        new Employee() { EmpID = 10, DeptID = 3, Name = "Malcolm Birt" , AgeInYrs = 41 } 
                    } 
                }
            };

            Console.WriteLine("------Employees in Each Department--------");

            var empInDept = lists
                .Select(emp => new
                {
                    Department = emp.DeptName,
                    Employee = emp.employee.Select(e => e.Name)
                });

            ObjectDumper.Write(empInDept, 1);


            Console.WriteLine("\n-------Average Age--------");

            // Average Age Per Department
            var avgAgePerDept = lists
                            .Select(emp => new
                            {
                                Department = emp.DeptName,
                                AverageAge = emp.employee.Average(avg => (double)avg.AgeInYrs)
                            });

            ObjectDumper.Write(avgAgePerDept, 1);

            Console.WriteLine("\n-------Employee > 30 years-------------");

            // Employees > 30 yrs
            var empGt30 = lists
                .Select(emp => new
                {
                    Department = emp.DeptName,
                    Emp = emp.employee.Where(em => em.AgeInYrs > 30)
                    .Select(e => new
                    {
                        EmployeeName = e.Name,
                        Age = e.AgeInYrs
                    })
                });

            ObjectDumper.Write(empGt30, 1);

            Console.WriteLine("\n----Count Employees in Each Department-----");

            // Count Employees Per Department
            var cntEmpPerDept = lists
                            .Select(emp => new
                            {
                                Department = emp.DeptName,
                                NoOfEmployees = emp.employee.Count()
                            });

            ObjectDumper.Write(cntEmpPerDept, 1);

            Console.WriteLine("\n------Sort By Employee Names------");

            var ordered = lists
               .Select(emp => new
               {
                   Department = emp.DeptName,
                   Employee = emp.employee.OrderBy(e => e.Name)
                   .Select(c => new
                            {
                                Name = c.Name
                            })
               });

            ObjectDumper.Write(ordered, 1);

            Console.ReadLine();
        }
    }

public class Department
{
    public int DeptID { get; set; }
    public string DeptName { get; set; }
    public List<Employee> employee { get; set; }

}

public class Employee
{
    public int EmpID { get; set; }
    public int DeptID { get; set; }
    public string Name { get; set; }
    public int AgeInYrs { get; set; }
}
}
