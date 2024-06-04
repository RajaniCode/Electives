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

namespace SILV3_UserControlNAvigation
{
    public partial class MainPage : UserControl
    {
        MyRef.ServiceClient Proxy;

        MyRef.Customer[] arr;



        public MainPage()
        {
            InitializeComponent();
            searchData.TextBoxChanged += new TextChangedEventHandler(searchData_TextBoxChanged); 
        }

        void searchData_TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            //USe Linq to Filter Data
            var FilteredData = from Cust in arr
                               where Cust.CustomerName.StartsWith(searchData.strData)
                               select Cust;

            //Convert the IEnumaration to Object Array
            object[] CollectionToBind = FilteredData.ToArray();

           

            detailedData.BindDataGrid(CollectionToBind);
            if (CollectionToBind.Length == 0 || CollectionToBind == null)
            {
                HtmlPage.Window.Alert("Sorry No Data Available..");
            }
        }               

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Proxy = new SILV3_UserControlNAvigation.MyRef.ServiceClient();
            Proxy.GetAllCustomersCompleted += new EventHandler<SILV3_UserControlNAvigation.MyRef.GetAllCustomersCompletedEventArgs>(Proxy_GetAllCustomersCompleted);
            Proxy.GetAllCustomersAsync();
        }

        void Proxy_GetAllCustomersCompleted(object sender, SILV3_UserControlNAvigation.MyRef.GetAllCustomersCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                arr = e.Result.ToArray(); 

                detailedData.BindDataGrid(arr); 
            }
        }
    }
}
