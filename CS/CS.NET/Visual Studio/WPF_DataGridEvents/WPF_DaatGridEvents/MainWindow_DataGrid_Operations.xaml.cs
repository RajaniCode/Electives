using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_DaatGridEvents
{
    /// <summary>
    /// Interaction logic for MainWindow_DataGrid_Operations.xaml
    /// </summary>
    public partial class MainWindow_DataGrid_Operations : Window
    {
        CompanyEntities objContext;

        bool isUpdateMode = false;

        Employee objEmpToEdit = null;

        public MainWindow_DataGrid_Operations()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            objContext = new CompanyEntities();
            dgEmp.ItemsSource = objContext.Employee;  
        }

        private void dgEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objEmpToEdit = dgEmp.SelectedItem as Employee;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            isUpdateMode = true;
            dgEmp.Columns[2].IsReadOnly = false;
            dgEmp.Columns[3].IsReadOnly = false;
        }

        private void dgEmp_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
                objContext.SaveChanges();
                MessageBox.Show("The Current row updation is complete..");  
        }
         

        private void dgEmp_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (isUpdateMode) //The Row is  edited
            {
                Employee TempEmp = (from emp in objContext.Employee
                                    where emp.EmpNo == objEmpToEdit.EmpNo
                                    select emp).First();


                FrameworkElement element_1 = dgEmp.Columns[2].GetCellContent(e.Row);
                if (element_1.GetType() == typeof(TextBox))
                {
                    var xxSalary = ((TextBox)element_1).Text;
                    objEmpToEdit.Salary = Convert.ToInt32(xxSalary);
                }
                FrameworkElement element_2 = dgEmp.Columns[3].GetCellContent(e.Row);
                if (element_2.GetType() == typeof(TextBox))
                {
                    var yyDeptNo = ((TextBox)element_2).Text;
                    objEmpToEdit.DeptNo = Convert.ToInt32(yyDeptNo);
                }
            }        
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (objEmpToEdit == null)
            {
                MessageBox.Show("Cannot delete the blank Entry");  
            }
            else
            {
                objContext.DeleteObject(objEmpToEdit);
                objContext.SaveChanges();
                MessageBox.Show("Record Deleted..");  
            }
        }



        

    

         
    }
}
