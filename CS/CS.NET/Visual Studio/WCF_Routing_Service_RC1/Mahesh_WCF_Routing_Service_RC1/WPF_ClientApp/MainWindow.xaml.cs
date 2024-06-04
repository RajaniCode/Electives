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

namespace WPF_ClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyRefQtrwiseSales.QtrwiseSalesClient ProxyQtrwiseSales;
        MyRefSalesData.SalesDataClient ProxySales;

        MyRefQtrwiseSales.Sales[] arrQtrSales;
        MyRefSalesData.SalesData[] arrSalesData;


        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                ProxyQtrwiseSales = new MyRefQtrwiseSales.QtrwiseSalesClient("clientEdpQtrwiseSales");
                ProxySales = new MyRefSalesData.SalesDataClient("clientEdpSalesData");

                arrQtrSales = ProxyQtrwiseSales.GetSalesDetsils();

                dgQtrwiseSales.DataContext = arrQtrSales;
                dgQtrwiseSales.ItemsSource = arrQtrSales;
 


                arrSalesData = ProxySales.GetSalesDetsils();

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
