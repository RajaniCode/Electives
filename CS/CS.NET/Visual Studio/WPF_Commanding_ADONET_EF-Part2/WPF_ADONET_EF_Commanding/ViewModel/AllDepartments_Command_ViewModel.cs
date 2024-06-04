using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using DataAccessLibrary;
using System.Collections.ObjectModel;

namespace WPF_ADONET_EF_Commanding
{
    public class AllDepartmentCommand : ICommand
    {
        AllDepartmentViewModel objAllDepartmentViewModel;

        public AllDepartmentCommand(AllDepartmentViewModel allDepartmentViewModel)
        {
            objAllDepartmentViewModel = allDepartmentViewModel;
        }

        public bool CanExecute(object parameter)
        {
            bool action = false;
            if (objAllDepartmentViewModel.Department.Count >= 0)
            {
                action = true;
            }
            return action;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            objAllDepartmentViewModel.GetAllDepartments();
        }
    }

    public class AllDepartmentViewModel
    {
        public ObservableCollection<Department> Department { get; set; }
        DataAccess objDs;

        public AllDepartmentViewModel()
        {
            Department = new ObservableCollection<Department>();
            objDs = new DataAccess();
        }

        public ICommand AllDepartments 
        {
            get
            {
                return new AllDepartmentCommand(this);
            } 
        }

        public void GetAllDepartments()
        {
            List<Department> lstDept = objDs.GetAllDepartments();

            foreach (Department Dept in lstDept)
            {
                Department.Add(Dept);   
            }
        }

    }

     
}
