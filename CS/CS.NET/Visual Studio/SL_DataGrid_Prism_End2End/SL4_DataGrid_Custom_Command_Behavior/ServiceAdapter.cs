using System;
using SL4_DataGrid_Custom_Command_Behavior.MyRef;

namespace SL4_DataGrid_Custom_Command_Behavior
{

    public interface IServiceAdapter
    {
        void GetEmployees(EventHandler<GetEmployeesCompletedEventArgs> evt);
        void CreateEmployee(EmployeeInfo objEmp, EventHandler<CreateNewEmployeeCompletedEventArgs> evt);
        void UpdateEmployee(EmployeeInfo objEmp, EventHandler<UpdateEmployeeCompletedEventArgs> evt);
        void DeleteEmployee(EmployeeInfo objEmp, EventHandler<DeleteEmployeeCompletedEventArgs> evt);
      
    }

    public class ServiceAdapter : IServiceAdapter
    {

        MyRef.ServiceClient Proxy;
        public ServiceAdapter()
        {
            Proxy = new ServiceClient(); 
        }
        public void GetEmployees(EventHandler<GetEmployeesCompletedEventArgs> evt)
        { 
            Proxy.GetEmployeesCompleted += evt;
            Proxy.GetEmployeesAsync();
        }

        public void CreateEmployee(EmployeeInfo objEmp, EventHandler<CreateNewEmployeeCompletedEventArgs> evt)
        {
            Proxy.CreateNewEmployeeCompleted += evt;
            Proxy.CreateNewEmployeeAsync(objEmp);  
        }

        public void UpdateEmployee(EmployeeInfo objEmp, EventHandler<UpdateEmployeeCompletedEventArgs> evt)
        {
            Proxy.UpdateEmployeeCompleted += evt;
            Proxy.UpdateEmployeeAsync(objEmp);  
        }

        public void DeleteEmployee(EmployeeInfo objEmp, EventHandler<DeleteEmployeeCompletedEventArgs> evt)
        {
            Proxy.DeleteEmployeeCompleted += evt;
            Proxy.DeleteEmployeeAsync(objEmp);  
        }


       
    }
}
