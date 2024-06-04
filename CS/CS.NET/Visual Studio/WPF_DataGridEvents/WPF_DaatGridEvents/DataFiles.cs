using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WPF_DaatGridEvents
{
    public class MyEmployee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
    }

    public class EmployeeCollection : ObservableCollection<MyEmployee>
    {
        public EmployeeCollection()
        {
            Add(new MyEmployee() { EmpNo = 101, EmpName = "Ramesh", DeptName = "IT", Designation = "Manager", Experience = 15, Salary = 300000 });
            Add(new MyEmployee() { EmpNo = 102, EmpName = "Ajay", DeptName = "Accts", Designation = "Clerk", Experience = 12, Salary = 200000 });
            Add(new MyEmployee() { EmpNo = 103, EmpName = "Atul", DeptName = "Tech", Designation = "Supervisor", Experience = 10, Salary = 400000 });
            Add(new MyEmployee() { EmpNo = 104, EmpName = "Narayan", DeptName = "Hrd", Designation = "Supervisor", Experience = 14, Salary = 400000 });
            Add(new MyEmployee() { EmpNo = 105, EmpName = "Baban", DeptName = "Hrd", Designation = "Manager", Experience = 18, Salary = 300000 });
            Add(new MyEmployee() { EmpNo = 106, EmpName = "Mandar", DeptName = "IT", Designation = "Operator", Experience = 12, Salary = 200000 });
            Add(new MyEmployee() { EmpNo = 107, EmpName = "Suraj", DeptName = "Accts", Designation = "Operator", Experience = 22, Salary = 200000 });
            Add(new MyEmployee() { EmpNo = 108, EmpName = "Chaitanya", DeptName = "Tech", Designation = "Supervisor", Experience = 13, Salary = 400000 });
            Add(new MyEmployee() { EmpNo = 109, EmpName = "Anand", DeptName = "Tech", Designation = "Manager", Experience = 16, Salary = 300000 });
            Add(new MyEmployee() { EmpNo = 110, EmpName = "Kapil", DeptName = "Hrd", Designation = "Clerk", Experience = 10, Salary = 200000 });
        }
    }
}
