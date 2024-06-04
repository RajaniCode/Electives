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


namespace Silverlight.Com.View.Client
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnAllEmployees_Click(object sender, RoutedEventArgs e)
        {
            AllEmployeesView objAllEmpView = new AllEmployeesView();
            grdAllEmp.Children.Add(objAllEmpView);  
        }

private void btnCreateEmployee_Click(object sender, RoutedEventArgs e)
{
    NewEmployeeView objNewEmpView = new NewEmployeeView();
    grdNewEmp.Children.Add(objNewEmpView);  
}

         
    }
}
