using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLINQGroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 1, FName = "John", MName = "", LName = "Shields", DOB = DateTime.Parse("12/11/1971"), Sex = 'M' });
            empList.Add(new Employee() { ID = 2, FName = "Mary", MName = "Matthew", LName = "Jacobs", DOB = DateTime.Parse("01/17/1961"), Sex = 'F' });
            empList.Add(new Employee() { ID = 3, FName = "Amber", MName = "Carl", LName = "Agar", DOB = DateTime.Parse("12/23/1971"), Sex = 'M' });
            empList.Add(new Employee() { ID = 4, FName = "Kathy", MName = "", LName = "Berry", DOB = DateTime.Parse("11/15/1976"), Sex = 'F' });
            empList.Add(new Employee() { ID = 5, FName = "Lena", MName = "Ashco", LName = "Bilton", DOB = DateTime.Parse("05/11/1978"), Sex = 'F' });
            empList.Add(new Employee() { ID = 6, FName = "Susanne", MName = "", LName = "Buck", DOB = DateTime.Parse("03/7/1965"), Sex = 'F' });
            empList.Add(new Employee() { ID = 7, FName = "Jim", MName = "", LName = "Brown", DOB = DateTime.Parse("09/11/1972"), Sex = 'M' });
            empList.Add(new Employee() { ID = 8, FName = "Jane", MName = "G", LName = "Hooks", DOB = DateTime.Parse("12/11/1972"), Sex = 'F' });
            empList.Add(new Employee() { ID = 9, FName = "Robert", MName = "", LName = "", DOB = DateTime.Parse("06/28/1964"), Sex = 'M' });
            empList.Add(new Employee() { ID = 10, FName = "Cindy", MName = "Preston", LName = "Fox", DOB = DateTime.Parse("01/11/1978"), Sex = 'M' });

            // Printing the List
            Console.WriteLine("\n{0,2} {1,7}    {2,8}      {3,8}      {4,23}      {5,3}",
               "ID", "FName", "MName", "LName", "DOB", "Sex");
            empList.ForEach(delegate(Employee e)
            {
                Console.WriteLine("{0,2} {1,7}    {2,8}      {3,8}      {4,23}    {5,3}",
                    e.ID, e.FName, e.MName, e.LName, e.DOB, e.Sex);
            });

            Console.ReadLine();



            // Group People by the First Letter of their FirstName
            var grpOrderedFirstLetter = empList.GroupBy(employees =>
                new String(employees.FName[0], 1)).OrderBy(employees => employees.Key.ToString());;
            
            foreach (var employee in grpOrderedFirstLetter)
            {
                Console.WriteLine("\n'Employees having First Letter {0}':", employee.Key.ToString());
                foreach (var empl in employee)
                {
                    Console.WriteLine(empl.FName);
                }
            }

            Console.ReadLine();

            

            // Group People by the Year in which they were born            
            var grpOrderedYr = empList.GroupBy(employees => employees.DOB.Year).OrderBy(employees => employees.Key);

            foreach (var employee in grpOrderedYr) 
            {
                Console.WriteLine("\nEmployees Born In the Year " + employee.Key);
                foreach (var empl in employee)
                {
                    Console.WriteLine("{0,2} {1,7}", empl.ID, empl.FName); 
                } 
            }
            Console.ReadLine();



            // Group people by the Year and Month in which they were born
            var grpOrderedYrMon = empList.GroupBy(employees =>
                new DateTime(employees.DOB.Year, employees.DOB.Month, 1)).OrderBy(employees => employees.Key); ;

            foreach (var employee in grpOrderedYrMon)
            {
                Console.WriteLine("\nEmployees Born in Year {0} - Month {1} is/are :", employee.Key.Year, employee.Key.Month);
                foreach (var empl in employee)
                {
                    Console.WriteLine("{0}: {1}", empl.ID, empl.FName);
                }
            }
            Console.ReadLine();



            // Count people grouped by the Year in which they were born
            var grpCountYrMon = empList.GroupBy(employees => employees.DOB.Year)
                .Select(lst => new {Year = lst.Key, Count = lst.Count()} );

            foreach (var employee in grpCountYrMon)
            {
                Console.WriteLine("\n{0} were born in {1}",  employee.Count, employee.Year);                
            }
            Console.ReadLine();    
        
            

            // Sex Ratio
            var ratioSex = empList.GroupBy(ra => ra.Sex)
              .Select( emp => new
              {
                  Sex = emp.Key,
                  Ratio = (emp.Count() * 100) / empList.Count
              });

            foreach (var ratio in ratioSex)
            {
                Console.WriteLine("\n{0} are {1}%", ratio.Sex, ratio.Ratio);
            }
            Console.ReadLine();    
        }

       
    }

    class Employee
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public DateTime DOB { get; set; }
        public char Sex { get; set; }
    }
}
