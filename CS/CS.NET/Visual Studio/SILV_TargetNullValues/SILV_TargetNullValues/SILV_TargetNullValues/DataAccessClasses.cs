using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace SILV_TargetNullValues
{
    public class clsEmployee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public decimal? Salary { get; set; }
    }

    public class EmployeeCollection : ObservableCollection<clsEmployee>
    {
        public EmployeeCollection()
        {
            Add(new clsEmployee() { EmpNo = 101, EmpName = "Emp_1", DeptName = "IT", Designation = "Manager", Salary = 78000 });
            Add(new clsEmployee() { EmpNo = 102, EmpName = "Emp_2", DeptName = "IT", Designation = "Engineer", Salary = 88000 });
            Add(new clsEmployee() { EmpNo = 103, EmpName = "Emp_3", DeptName = "ACCT", Designation = "Manager" });
            Add(new clsEmployee() { EmpNo = 104, EmpName = "Emp_4", DeptName = "ACCT", Designation = "Clerk", Salary = 68000 });
            Add(new clsEmployee() { EmpNo = 105, EmpName = "Emp_5", Designation = "Manager", Salary = 38000 });
            Add(new clsEmployee() { EmpNo = 106, EmpName = "Emp_6", DeptName = "HRD", Salary = 88000 });
            Add(new clsEmployee() { EmpNo = 107, EmpName = "Emp_7", DeptName = "HRD", Designation = "HEAD", Salary = 98000 });
            Add(new clsEmployee() { EmpNo = 108, EmpName = "Emp_8", Designation = "Manager", Salary = 48000 });
            Add(new clsEmployee() { EmpNo = 109, EmpName = "Emp_9", DeptName = "IT", Salary = 58000 });
            Add(new clsEmployee() { EmpNo = 110, EmpName = "Emp_10", Designation = "Manager", Salary = 78000 });
        }
    }
}
