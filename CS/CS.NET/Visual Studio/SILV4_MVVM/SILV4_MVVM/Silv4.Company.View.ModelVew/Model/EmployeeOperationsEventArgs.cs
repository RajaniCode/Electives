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

using Silv4.Company.View.ModelVew.MyRef;
using System.Collections;
using System.Collections.Generic;

namespace Silv4.Company.View.ModelVew.Model
{
    public class EmployeeOperationsEventArgs : EventArgs
    {
        //Declare a Enumerable, representing return values, when call is made to the service
        public IEnumerable<Employee> AllEmployees { get; set; }

        public EmployeeOperationsEventArgs(IEnumerable<Employee> allEmployees)
        {
            AllEmployees = allEmployees;
        }
    }
}
