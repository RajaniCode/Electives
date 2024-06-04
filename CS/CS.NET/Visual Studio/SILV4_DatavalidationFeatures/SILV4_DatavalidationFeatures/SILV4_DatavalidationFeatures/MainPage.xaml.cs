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

namespace SILV4_DatavalidationFeatures
{
    public partial class MainPage : UserControl
    {
        Employee objEmp;

        EmployeeCollection objCol;
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            objEmp = new Employee();
            objCol = new EmployeeCollection();

            objEmp = (from emp in objCol.ColEmployee
                     select new Employee()
                     {
                         EmpNo = emp.EmpNo,
                         EmpName = emp.EmpName,
                         DeptNo = emp.DeptNo,
                         Salary = emp.Salary
                     }).First() ;

             
            this.DataContext = this;

             grdRecord.DataContext = objEmp;

           
        }

        

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(txtEno) || Validation.GetHasError(txtEname)
                || Validation.GetHasError(txtSalary) || Validation.GetHasError(txtDno))
            {
                MessageBox.Show("Please satisfy the Validation Condition");
            }
            else
            {
                objCol.ColEmployee.Add(objEmp);
                dgEmp.DataContext = objCol.ColEmployee;
            }
        }

       
    }
}
