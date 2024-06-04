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
using System.Collections.ObjectModel;
using System.Windows.Browser;

namespace SILV3_DMLClientApplication
{
    public partial class DeletePage : UserControl
    {
        MyRef.DMLServiceClient Proxy;

        public DeletePage()
        {
            InitializeComponent();
            dfDeleteEmp.DeletingItem += new EventHandler<System.ComponentModel.CancelEventArgs>(dfDeleteEmp_DeletingItem);
        }

        void dfDeleteEmp_DeletingItem(object sender, System.ComponentModel.CancelEventArgs e)
        {
              
            Proxy.DeleteEmployeeByEmpNoCompleted += new EventHandler<SILV3_DMLClientApplication.MyRef.DeleteEmployeeByEmpNoCompletedEventArgs>(Proxy_DeleteEmployeeByEmpNoCompleted);
            Proxy.DeleteEmployeeByEmpNoAsync((MyRef.clsEmployee)dfDeleteEmp.CurrentItem);
        }

        void Proxy_DeleteEmployeeByEmpNoCompleted(object sender, SILV3_DMLClientApplication.MyRef.DeleteEmployeeByEmpNoCompletedEventArgs e)
        {
            if ((int?)e.Result != null)
            {
                if (e.Result == 1)
                {
                    HtmlPage.Window.Alert("Record Deleted Successfully....");
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            
            Proxy = new SILV3_DMLClientApplication.MyRef.DMLServiceClient();
            Proxy.GetAllEmployeeCompleted +=new EventHandler<SILV3_DMLClientApplication.MyRef.GetAllEmployeeCompletedEventArgs>(Proxy_GetAllEmployeeCompleted);
            Proxy.GetAllEmployeeAsync(); 
        }

        void Proxy_GetAllEmployeeCompleted(object sender, SILV3_DMLClientApplication.MyRef.GetAllEmployeeCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                dfDeleteEmp.ItemsSource = e.Result;
            }
        }
    }
}
