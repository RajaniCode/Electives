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

using Silverlight.Com.Client.MyRef;
using System.Collections.ObjectModel;

namespace Silverlight.Com.Client
{

    /// <summary>
    /// The Class Act as a ViewModel class, this makes async call to WCF service and retrieve all Employees. 
    /// </summary>

    public class AllEmployeeViewModel
    {
         public  ObservableCollection<clsEmployee>  Employees{ get; set; }

        ServiceClient Proxy;
        
        public AllEmployeeViewModel()
        {
            Employees = new ObservableCollection<clsEmployee>();
            Proxy = new ServiceClient();
        }

        public ICommand GetEmployees
        {
            get
            {
                return new GetAllEmployeeCommand(this);  
            }
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
                foreach (clsEmployee Emp in e.Result)
                {
                    Employees.Add(Emp);  
                }
            }
        }


     
    }
}
