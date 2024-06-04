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
 
namespace Silv4.Company.View.ModelVew.Model
{
    //This class is responsible for making call to the Service and perform Data operations
    public class EmployeeModel : IEmployee
    {
        ServiceClient Proxy;

        Employee[] arrEmp;

        public EmployeeModel()
        {
            Proxy = new ServiceClient(); 
        }
        public void GetAllEmployees()
        {
            Proxy.GetAllEmployeesCompleted += new EventHandler<GetAllEmployeesCompletedEventArgs>(Proxy_GetAllEmployeesCompleted);
            Proxy.GetAllEmployeesAsync(); 
        }

        void Proxy_GetAllEmployeesCompleted(object sender, GetAllEmployeesCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                arrEmp = e.Result;
                //Raise The event
                GetAllEmployeesCompleted(this, new EmployeeOperationsEventArgs(arrEmp));     
            }
        }

        public void CreateEmployee()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<EmployeeOperationsEventArgs> GetAllEmployeesCompleted;

        public event EventHandler NewEmployeeCreated;
    }
}
