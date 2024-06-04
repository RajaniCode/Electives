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
    public partial class UpdatePage : UserControl
    {

        MyRef.DMLServiceClient Proxy;

        ObservableCollection<MyRef.clsEmployee> _colEmp;

        public UpdatePage()
        {
            InitializeComponent();
            dfUpdateEmp.EditEnded += new EventHandler<DataFormEditEndedEventArgs>(dfUpdateEmp_EditEnded);
        }

        void dfUpdateEmp_EditEnded(object sender, DataFormEditEndedEventArgs e)
        {
            Proxy.UpdateEmployeeCompleted += new EventHandler<SILV3_DMLClientApplication.MyRef.UpdateEmployeeCompletedEventArgs>(Proxy_UpdateEmployeeCompleted);
            Proxy.UpdateEmployeeAsync((MyRef.clsEmployee)dfUpdateEmp.CurrentItem);
 
        }

        void Proxy_UpdateEmployeeCompleted(object sender, SILV3_DMLClientApplication.MyRef.UpdateEmployeeCompletedEventArgs e)
        {
            if ((int?)e.Result != null)
            {
                if (e.Result == 1)
                {
                    HtmlPage.Window.Alert("Record Updated Successfully");             
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Proxy = new SILV3_DMLClientApplication.MyRef.DMLServiceClient();
            Proxy.GetAllEmployeeCompleted += new EventHandler<SILV3_DMLClientApplication.MyRef.GetAllEmployeeCompletedEventArgs>(Proxy_GetAllEmployeeCompleted);
            Proxy.GetAllEmployeeAsync();

        //    dfUpdateEmp.CommandButtonsVisibility = DataFormCommandButtonsVisibility.All;
          
        }

        void Proxy_GetAllEmployeeCompleted(object sender, SILV3_DMLClientApplication.MyRef.GetAllEmployeeCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                _colEmp = e.Result;
                dfUpdateEmp.ItemsSource = e.Result;
            }
        }
    }
}
