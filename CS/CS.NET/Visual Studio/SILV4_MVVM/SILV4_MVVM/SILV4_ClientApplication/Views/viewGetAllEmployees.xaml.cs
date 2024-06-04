using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Silv4.Company.View.ModelVew;
using Silv4.Company.View.ModelVew.MyRef;
using Silv4.Company.View.ModelVew.ViewModel;
using System.Windows.Browser;
using System.Collections.ObjectModel;

namespace SILV4_ClientApplication.Views
{
    public partial class viewGetAllEmployees : UserControl
    {

        EmployeeViewModel empViewModel;

        public viewGetAllEmployees()
        {
            InitializeComponent();
            empViewModel = new EmployeeViewModel();
            empViewModel.GetAllEmployeeView += new EventHandler(empViewModel_GetAllEmployeeView);
        }

        void empViewModel_GetAllEmployeeView(object sender, EventArgs e)
        {
            ObservableCollection<Employee> Employees = empViewModel.AllEmployees;
            dgEmp.ItemsSource = Employees;
            HtmlPage.Window.Alert("Data Fetched..");  
        }

        private void btnLoadEmployee_Click(object sender, RoutedEventArgs e)
        {
            empViewModel.GetAllEmployees();
        }
    }
}
