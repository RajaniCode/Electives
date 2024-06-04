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
using System.Windows.Data;

namespace SILV3_DMLClientApplication
{
    public partial class GetAllPage : UserControl
    {

        MyRef.DMLServiceClient Proxy;

        ObservableCollection<MyRef.clsEmployee> _colEmp;

        public GetAllPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Proxy = new SILV3_DMLClientApplication.MyRef.DMLServiceClient();
            Proxy.GetAllEmployeeCompleted += new EventHandler<SILV3_DMLClientApplication.MyRef.GetAllEmployeeCompletedEventArgs>(Proxy_GetAllEmployeeCompleted);
            Proxy.GetAllEmployeeAsync();
        }

        void Proxy_GetAllEmployeeCompleted(object sender, SILV3_DMLClientApplication.MyRef.GetAllEmployeeCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                _colEmp = e.Result;

                dgEmp.ItemsSource = new PagedCollectionView(e.Result); 
                //dgEmp.ItemsSource = _colEmp; 
                
            }
             
        }
    }
}
