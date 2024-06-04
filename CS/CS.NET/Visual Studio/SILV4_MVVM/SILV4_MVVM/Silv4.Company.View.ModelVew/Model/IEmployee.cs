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

namespace Silv4.Company.View.ModelVew.Model
{
    public interface IEmployee
    {
        void GetAllEmployees();
        void CreateEmployee();
        //The Following event is used for notification
        //for the Operation completed by the ViewModel.
        //This is REquired because the SIlverlight applications
        //makes async call to service. 

        event EventHandler<EmployeeOperationsEventArgs> GetAllEmployeesCompleted;
        event EventHandler NewEmployeeCreated;

    }
}
