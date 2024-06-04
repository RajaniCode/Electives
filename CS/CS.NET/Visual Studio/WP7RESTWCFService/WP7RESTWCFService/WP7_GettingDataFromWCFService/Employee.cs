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
using System.Runtime.Serialization;

namespace WP7_GettingDataFromWCFService
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int DeptNo { get; set; }
        public int Salary { get; set; }
    }
}
