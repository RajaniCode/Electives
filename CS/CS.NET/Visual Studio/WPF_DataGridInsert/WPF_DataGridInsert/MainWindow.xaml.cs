using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_DataGridInsert
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clsEmployee objEmpToAdd;
        DataAccess objDs; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            objDs = new DataAccess();
            dgEmp.ItemsSource = objDs.GetAllEmployee(); 
        }

        private void dgEmp_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                FrameworkElement element_EmpNo = dgEmp.Columns[0].GetCellContent(e.Row);
                if (element_EmpNo.GetType() == typeof(TextBox))
                {
                    var eno = ((TextBox)element_EmpNo).Text;
                    objEmpToAdd.EmpNo = Convert.ToInt32(eno);
                }
                FrameworkElement element_EmpName = dgEmp.Columns[1].GetCellContent(e.Row);
                if (element_EmpName.GetType() == typeof(TextBox))
                {
                    var ename = ((TextBox)element_EmpName).Text;
                    objEmpToAdd.EmpName = ename;
                }
                FrameworkElement element_Salary = dgEmp.Columns[2].GetCellContent(e.Row);
                if (element_Salary.GetType() == typeof(TextBox))
                {
                    var salary = ((TextBox)element_Salary).Text;
                    objEmpToAdd.Salary = Convert.ToInt32(salary);
                }
                FrameworkElement element_DeptNo = dgEmp.Columns[3].GetCellContent(e.Row);
                if (element_DeptNo.GetType() == typeof(TextBox))
                {
                    var dno = ((TextBox)element_DeptNo).Text;
                    objEmpToAdd.DeptNo = Convert.ToInt32(dno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
        }

        private void dgEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objEmpToAdd = dgEmp.SelectedItem as clsEmployee;
        }

        private void dgEmp_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var Res =  MessageBox.Show("Do you want to Create this new entry", "Confirm", MessageBoxButton.YesNo);
                if (Res == MessageBoxResult.Yes)
                {
                    objDs.InsertEmployee(objEmpToAdd); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
            }
        }
    }
}
