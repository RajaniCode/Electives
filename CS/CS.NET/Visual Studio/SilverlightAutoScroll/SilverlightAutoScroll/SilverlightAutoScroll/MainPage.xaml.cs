using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SilverlightAutoScroll
{
    public partial class MainPage : UserControl
    {
        Employee emp;
        public MainPage()
        {
            InitializeComponent();
            emp = new Employee();
            empList.DataContext = emp.GetEmployeeList();
        }

        private void btnJumpIndex_Click(object sender, RoutedEventArgs e)
        {            
            // Add an additional check that string is a valid number
            int idx = Convert.ToInt32(txtIdx.Text);
            int jmpIdx = idx - 1;
            if (empList.Items.Any() && empList.Items.Count > jmpIdx)
            {
                object item = empList.Items.ElementAt(jmpIdx);
                empList.ScrollIntoView(item);
                empList.SelectedItem = item;
            }
        }

        private void btnJump_Click(object sender, RoutedEventArgs e)
        {
            if (empList.Items.Any())
            {
                object item = empList.Items.Last();               
                empList.ScrollIntoView(item);
                empList.SelectedItem = item;
            }
        }


    }
}
