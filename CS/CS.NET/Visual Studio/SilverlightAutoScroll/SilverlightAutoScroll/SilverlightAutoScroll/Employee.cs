using System;
using System.Collections.Generic;

namespace SilverlightAutoScroll
{
    public class Employee
    {
public int ID { get; set; }
public string FName { get; set; }
public string MName { get; set; }
public string LName { get; set; }

        public List<Employee> GetEmployeeList()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 1, FName = "John", MName = "", LName = "Shields" });
            empList.Add(new Employee() { ID = 2, FName = "Mary", MName = "Matthew", LName = "Jacobs" });
            empList.Add(new Employee() { ID = 3, FName = "Amber", MName = "Carl", LName = "Agar" });
            empList.Add(new Employee() { ID = 4, FName = "Kathy", MName = "", LName = "Berry" });
            empList.Add(new Employee() { ID = 5, FName = "Lena", MName = "Ashco", LName = "Bilton" });
            empList.Add(new Employee() { ID = 6, FName = "Susanne", MName = "", LName = "Buck" });
            empList.Add(new Employee() { ID = 7, FName = "Jim", MName = "", LName = "Brown" });
            empList.Add(new Employee() { ID = 8, FName = "Jane", MName = "G", LName = "Hooks"});
            empList.Add(new Employee() { ID = 9, FName = "Robert", MName = "", LName = "" });
            empList.Add(new Employee() { ID = 10, FName = "Krishna", MName = "Murali", LName = "Sunkam" });
            empList.Add(new Employee() { ID = 11, FName = "Cindy", MName = "Preston", LName = "Fox" });
            empList.Add(new Employee() { ID = 12, FName = "Nicole", MName = "G", LName = "Holiday" });
            empList.Add(new Employee() { ID = 13, FName = "Sandra", MName = "T", LName = "Feng" });
            empList.Add(new Employee() { ID = 14, FName = "Roberto", MName = "", LName = "Tamburello" });
            empList.Add(new Employee() { ID = 15, FName = "Cynthia", MName = "O", LName = "Lugo" });
            empList.Add(new Employee() { ID = 16, FName = "Yuhong", MName = "R", LName = "Li" });   
            return empList;
        }
    }

}
