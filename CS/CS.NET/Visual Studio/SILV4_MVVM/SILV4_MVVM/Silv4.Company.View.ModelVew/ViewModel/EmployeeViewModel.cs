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

using Silv4.Company.View.ModelVew.Model;
using System.Collections.ObjectModel;

namespace Silv4.Company.View.ModelVew.ViewModel
{

    //The class Makes the use of the EmployeeModel class
    //by using the IEmployee interface it subscribe to the Model class
    //to perform operations.
    //This class makes use of  events for the notification to UI.
    public class EmployeeViewModel
    {
        IEmployee empModel;

        //The important here is that, declare 
        //collection type so that, it will 
        //contain collection result so that
        //it will be made available to View

        ObservableCollection<Employee> allEmployees = new ObservableCollection<Employee>();

        public ObservableCollection<Employee> AllEmployees
        {
            get { return allEmployees; }
        }


        //Now you need to declare events.
        //These events will receive notification form
        //Model and fire on the view

        public event EventHandler GetAllEmployeeView;
        public event EventHandler NewEmployeeCreatedView;

        //This is used for Xaml binding in View
        public EmployeeViewModel()
            : this(new EmployeeModel())
        {

        }
        public EmployeeViewModel(IEmployee eModel)
        {
            empModel = eModel;
            empModel.GetAllEmployeesCompleted += new EventHandler<EmployeeOperationsEventArgs>(eModel_GetAllEmployeesCompleted);
        }

        void eModel_GetAllEmployeesCompleted(object sender, EmployeeOperationsEventArgs e)
        {
            Application.Current.RootVisual.Dispatcher.BeginInvoke(() =>
            {
                allEmployees.Clear();

                foreach (Employee emp in e.AllEmployees)
                {
                    allEmployees.Add(emp);
                }

                //Raise event of completion
                if (GetAllEmployeeView != null)
                {
                    GetAllEmployeeView(this, null);
                }

            }
                );
        }

        //Make call to Method in the Model Class

        public void GetAllEmployees()
        {
            empModel.GetAllEmployees();
        }

    }
}
