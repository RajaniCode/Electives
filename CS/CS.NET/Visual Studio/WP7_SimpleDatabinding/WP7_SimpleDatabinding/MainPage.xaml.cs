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
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;

namespace WP7_SimpleDatabinding
{
    
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

         // SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;

             SupportedOrientations = SupportedPageOrientation.Portrait;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            lstEmployees.DataContext = new EmployeeCollection();
            
        }

        private void sliderX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            listProjection.RotationX = sliderX.Value;
        }

        private void sliderY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            listProjection.RotationY = sliderY.Value;
        }
    }

    public class clsEmployee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
    }

    public class EmployeeCollection : ObservableCollection<clsEmployee>
    {
        public EmployeeCollection()
        {
            Add(new clsEmployee() {EmpNo=101,EmpName="EmpName_1",Salary=1000 });
            Add(new clsEmployee() { EmpNo = 102, EmpName = "EmpName_2", Salary = 2000 });
            Add(new clsEmployee() { EmpNo = 103, EmpName = "EmpName_3", Salary = 3000 });
            Add(new clsEmployee() { EmpNo = 104, EmpName = "EmpName_4", Salary = 4000 });
            Add(new clsEmployee() { EmpNo = 105, EmpName = "EmpName_5", Salary = 5000 });
            Add(new clsEmployee() { EmpNo = 106, EmpName = "EmpName_6", Salary = 6000 });
        }
    }
}