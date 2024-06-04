using System;
using System.Windows.Input;
using DataAccessLibrary;

namespace WPF_ADONET_EF_Commanding
{
    public class CreateEmployeeCommand : ICommand
    {
        CreateEmployeeViewModel objCreateEmp;
        public CreateEmployeeCommand(CreateEmployeeViewModel createEmp)
        {
            objCreateEmp = createEmp;
        }
        public bool CanExecute(object parameter)
        {
            bool action = false;

            if (objCreateEmp.NewEmployee != null)
            {
                action = true;
            }

            return action; 
        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            objCreateEmp.InsertNewEmployee(objCreateEmp.NewEmployee);  
        }
    }


    public class CreateEmployeeViewModel
    {
        public Employee NewEmployee { get; set; }

        DataAccess objDs;

        public CreateEmployeeViewModel()
        {
            NewEmployee = new Employee();
            objDs = new DataAccess(); 
        }
        public ICommand CreateNewEmployee 
        {
            get 
            {
                return new CreateEmployeeCommand(this); 
            } 
        }
        public void InsertNewEmployee(Employee objEmp)
        {
            objDs.CreateEmployee(objEmp);  
        }
    }
}
