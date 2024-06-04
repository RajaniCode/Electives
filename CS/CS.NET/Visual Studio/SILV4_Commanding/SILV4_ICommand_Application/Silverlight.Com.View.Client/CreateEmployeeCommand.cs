using System;
using System.Windows.Input;

namespace Silverlight.Com.View.Client
{
    public class CreateEmployeeCommand :ICommand
    {

        CreateNewEmployeeViewModel NewEmpViewModel;

        public CreateEmployeeCommand(CreateNewEmployeeViewModel newEmpViewModel)
        {
            NewEmpViewModel = newEmpViewModel;
        }


        public bool CanExecute(object parameter)
        {
            bool action = false;

            if (NewEmpViewModel.Employee != null)
            {
                action = true;
            }
            return action;

        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //Make call to the ViewModel
            NewEmpViewModel.InsertEmployee(NewEmpViewModel.Employee);  
        }
    }
}

