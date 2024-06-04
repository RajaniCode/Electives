    using System.Collections.Generic;

    public class EmployeeList
    {
        static EmployeeList()
        {
            emp = new List<Employee>();
            emp.Add(new Employee() { EmpID = 1, DeptID = 1, EmpName = "Jack Nolas" });
            emp.Add(new Employee() { EmpID = 2, DeptID = 4, EmpName = "Mark Pine" });
            emp.Add(new Employee() { EmpID = 3, DeptID = 3, EmpName = "Sandra Simte" });
            emp.Add(new Employee() { EmpID = 4, DeptID = 4, EmpName = "Larry Lo" });
            emp.Add(new Employee() { EmpID = 5, DeptID = 3, EmpName = "Sudhir Panj" });
            emp.Add(new Employee() { EmpID = 6, DeptID = 2, EmpName = "Kathy K" });
            emp.Add(new Employee() { EmpID = 7, DeptID = 1, EmpName = "Kaff Joe" });
            emp.Add(new Employee() { EmpID = 8, DeptID = 1, EmpName = "Su Lie" });
        }

        public static List<Employee> emp { get; set; }
    }

    public class Employee
    {
        public int EmpID { get; set; }
        public int DeptID { get; set; }
        public string EmpName { get; set; }
    }
