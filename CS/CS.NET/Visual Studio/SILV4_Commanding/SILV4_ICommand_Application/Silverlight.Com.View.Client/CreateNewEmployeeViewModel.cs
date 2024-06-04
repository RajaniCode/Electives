using System;
using System.Windows.Input;
using Silverlight.Com.View.Client.MyRef;

namespace Silverlight.Com.View.Client
{
    public class CreateNewEmployeeViewModel
    {
        public clsEmployee Employee { get; set; }

        ServiceClient Proxy;

        int Res = 0;
        
        public CreateNewEmployeeViewModel()
        {
            Employee = new clsEmployee();
            Proxy = new ServiceClient(); 
        }


        public ICommand CreateEmployee
        {
            get
            {
                return new CreateEmployeeCommand(this); 
            }
        }


        public void InsertEmployee(clsEmployee objEmp)
        {
            Proxy.InsertEmployeeCompleted += new EventHandler<InsertEmployeeCompletedEventArgs>
                (Proxy_InsertEmployeeCompleted);
            Proxy.InsertEmployeeAsync(objEmp); 

        }

        void Proxy_InsertEmployeeCompleted(object sender, InsertEmployeeCompletedEventArgs e)
        {
            
                Res = e.Result;
             
        }
    }
}
