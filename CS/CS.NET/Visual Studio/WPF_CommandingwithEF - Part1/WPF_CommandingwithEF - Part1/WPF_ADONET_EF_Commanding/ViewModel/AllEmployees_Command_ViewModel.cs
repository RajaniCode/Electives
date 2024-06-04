using System;
using System.Collections.Generic;
using System.Windows.Input;
using DataAccessLibrary;
using System.Collections.ObjectModel; 

namespace WPF_ADONET_EF_Commanding
{
    public class AllEmployeesCommand : ICommand
    {

        AllEmployeeViewModel EmpViewModel;

        public AllEmployeesCommand(AllEmployeeViewModel empViewModel)
        {
            EmpViewModel = empViewModel;
        }
        public bool CanExecute(object parameter)
        {
            bool action = false;

            if (EmpViewModel.Employees.Count >= 0)
            {
                action = true;
            }

            return action;
        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            EmpViewModel.ViweAllEmployees();
        }
    }

    public class AllEmployeeViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }

        DataAccess objDs;

        public AllEmployeeViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            objDs = new DataAccess(); 
        }

        public ICommand AllEmployees 
        {
            get 
            {
                return new AllEmployeesCommand(this);  
            }
        }
        public void ViweAllEmployees()
        {
            List<Employee> lstEmp = objDs.GetAllEmployees();

            foreach (Employee Emp in lstEmp)
            {
                Employees.Add(Emp);  
            }
        }
    }
}
