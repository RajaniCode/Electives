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
using System.Windows.Browser;

namespace SILV3_DMLClientApplication
{
    public partial class InsertPage : UserControl
    {

        MyRef.DMLServiceClient Proxy;
        MyRef.clsEmployee objEmp; 


        public InsertPage()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement Element in LayoutRoot.Children)
            {
                if (Element.GetType() == typeof(System.Windows.Controls.TextBox))
                {
                    ((TextBox)Element).Text = "";
                }
            }

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Proxy = new SILV3_DMLClientApplication.MyRef.DMLServiceClient();
            objEmp = new SILV3_DMLClientApplication.MyRef.clsEmployee();
            
            objEmp.EmpNo = Convert.ToInt32(txtEmpNo.Text);
            objEmp.EmpName = txtEmpName.Text;
            objEmp.Salary = Convert.ToInt32(txtSalary.Text);
            objEmp.DeptNo = Convert.ToInt32(txtDeptNo.Text);

            Proxy.CreateEmployeeCompleted += new EventHandler<SILV3_DMLClientApplication.MyRef.CreateEmployeeCompletedEventArgs>(Proxy_CreateEmployeeCompleted);
            Proxy.CreateEmployeeAsync(objEmp); 
 
        }

        void Proxy_CreateEmployeeCompleted(object sender, SILV3_DMLClientApplication.MyRef.CreateEmployeeCompletedEventArgs e)
        {
            if ((int?)e.Result != null)
            {
                if (e.Result == 1)
                {
                    HtmlPage.Window.Alert("Record Inserted Successfully"); 
                }
            }
        }
    }
}
