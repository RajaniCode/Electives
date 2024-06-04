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
using System.Collections.ObjectModel;

namespace WPF_Client_RoutingService
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        MyRefQtrSales.QtrwiseSalesClient ProxyQtrwsieSales;
        MyRefSalesData.SalesDataClient ProxySalesData;

        MyRefQtrSales.Sales[] arrQtrSales;
        MyRefSalesData.SalesData[] arrSalesData;


        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }

        void Window1_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                ProxyQtrwsieSales = new WPF_Client_RoutingService.MyRefQtrSales.QtrwiseSalesClient("clientEdpQtrwiseSales");

                arrQtrSales = ProxyQtrwsieSales.GetSalesDetsils();


                dgQtrwiseSales.DataContext = arrQtrSales; 
                dgQtrwiseSales.ItemsSource = arrQtrSales;


                ProxySalesData = new WPF_Client_RoutingService.MyRefSalesData.SalesDataClient("clientEdpSalesData");
                arrSalesData = ProxySalesData.GetSalesDetsils();
                dgSalesData.DataContext = arrSalesData;
                dgSalesData.ItemsSource = arrSalesData;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
    }
}
