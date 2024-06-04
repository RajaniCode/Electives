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



namespace Silverlight.Com.Client
{
    /// <summary>
    /// The Following Class is used to Define The Actions to be performed by the UI.
    /// This Defines the Contract between the Model and UI.
    /// </summary>

    public class GetAllEmployeeCommand : ICommand
    {

        AllEmployeeViewModel EmployeeViewModel;

        public GetAllEmployeeCommand(AllEmployeeViewModel empViewModel)
        {
            EmployeeViewModel = empViewModel;
        }


        public bool CanExecute(object parameter)
        {

            bool action = false;

            //Check wheather the Data is retrived or not

            if (EmployeeViewModel.Employees.Count >= 0)
            {
                action =  true;
            }
            return action;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //Make Call to ViewModel Class for retriving the Employees
            EmployeeViewModel.GetAllEmployees();  
        }
    }
}
