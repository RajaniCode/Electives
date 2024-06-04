using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using DataAccessLibrary;
using System.Collections.ObjectModel;
 
namespace WPF_ADONET_EF_Commanding
{
    public class EmployeeByDeptNameCommand : ICommand
    {
        EmployeeByDeptNameViewModel objEmployeeByDeptNameViewModel;   

        public EmployeeByDeptNameCommand(EmployeeByDeptNameViewModel empByDeptNameViewModel)
        {
            objEmployeeByDeptNameViewModel = empByDeptNameViewModel;
        }

        public bool CanExecute(object parameter)
        {
            bool action = false;
            if (objEmployeeByDeptNameViewModel.Employees.Count >=0)
            {
                action = true;
            }
            return action;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            objEmployeeByDeptNameViewModel.GetAllEmployeesByDeptName(objEmployeeByDeptNameViewModel.Dept); 
        }
    }

    public class EmployeeByDeptNameViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }

        public Department Dept { get; set; }

        DataAccess objDs;

        public EmployeeByDeptNameViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            Dept = new Department();
            objDs = new DataAccess();
        }

        public ICommand AllEmployeesByDeptName 
        {
            get
            { return new EmployeeByDeptNameCommand(this);
            }
        }

        public void GetAllEmployeesByDeptName(Department Dept)
        {
            List<Employee> lstEmp = objDs.GetAllEmployeeBeDeptName(Dept.Dname);
            foreach (Employee Emp in lstEmp)
            {
                Employees.Add(Emp); 
            }
        }
    }
     

}
