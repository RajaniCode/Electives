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

using System.Net;
using System.Runtime.Serialization;

namespace WPF_RESTCLient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window1_Loaded);
        }
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAndDisplayEmployeeInformation();

            LoadAndDisplayQuarterWiseSalesStatatics();
            LoadAndDisplaySalesDataStatatics();
            LoadAndDIsplayStatewiseSales();
        }

        //Method for making request for 'GetAllEmploye' operations from the service
        private void LoadAndDisplayEmployeeInformation()
        {
            //USed to make request to URI
            WebRequest myRequest = WebRequest.Create("http://localhost/WCF_Rest_WPF/CService.svc/GetAllEmployee");
            //Provides response from a URI.
            WebResponse myResponse = myRequest.GetResponse();
            //USed to Serialize and Deserialize instance of a type into an XML stream
            DataContractSerializer RecData = new DataContractSerializer(typeof(List<clsDataContracts.clsEmployee>));
            var CollectionEmployees = RecData.ReadObject(myResponse.GetResponseStream());
            this.lstEmpData.DataContext = CollectionEmployees;
        }

        //Method for making request for 'GetSalesDetails' operations from the service
        private void LoadAndDisplayQuarterWiseSalesStatatics()
        {
            WebRequest myRequest = WebRequest.Create("http://localhost/WCF_Rest_WPF/CService.svc/GetSalesDetails");
            WebResponse myResponse = myRequest.GetResponse();
            DataContractSerializer RecData = new DataContractSerializer(typeof(List<clsDataContracts.clsSales>));
           var CollectionSales = RecData.ReadObject(myResponse.GetResponseStream());

            #region Code for putting data from  'CollectionSales' to KeyValuePair
            
            //Convert the received object into the original collection
            List<clsDataContracts.clsSales> lstQtrwiseSales = (List<clsDataContracts.clsSales>)CollectionSales;
            
            //Set the size as the number of records in the received collection 
            KeyValuePair<string, decimal>[] arrGraphData = new KeyValuePair<string, decimal>[lstQtrwiseSales.Count];
          int i = 0;
            foreach (var item in lstQtrwiseSales)
            {
                arrGraphData[i] = new KeyValuePair<string, decimal>(item.CompanyName, item.Q1);
                arrGraphData[i] = new KeyValuePair<string, decimal>(item.CompanyName, item.Q2);
                arrGraphData[i] = new KeyValuePair<string, decimal>(item.CompanyName, item.Q3);
                arrGraphData[i] = new KeyValuePair<string, decimal>(item.CompanyName, item.Q4);
                i++;
            }

            chartQtrwiseSalesColumn.DataContext = arrGraphData;
            columnQtrWiseSalesChart.ItemsSource = arrGraphData;
            #endregion
        }

        //Method for making request for 'GetSalesData' operations from the service
        private void LoadAndDisplaySalesDataStatatics()
        {
            WebRequest myRequest = WebRequest.Create("http://localhost/WCF_Rest_WPF/CService.svc/GetSalesData");
            WebResponse myResponse = myRequest.GetResponse();
            DataContractSerializer RecData = new DataContractSerializer(typeof(List<clsDataContracts.clsSalesData>));
            var CollectionSalesData = RecData.ReadObject(myResponse.GetResponseStream());

            #region Code for putting data from  'CollectionSales' to KeyValuePair

            //Convert the received object into the original collection
            List<clsDataContracts.clsSalesData> lstSalesData = (List<clsDataContracts.clsSalesData>)CollectionSalesData;

            //Set the size as the number of records in the received collection 
            KeyValuePair<string, decimal>[] arrGraphData = new KeyValuePair<string, decimal>[lstSalesData.Count];

            int i = 0;
            foreach (var item in lstSalesData)
            {
                arrGraphData[i] = new KeyValuePair<string, decimal>(item.ItemName, item.SalesQty);
                i++;
            }

            chartSalesDataColumn.DataContext = arrGraphData;
            lineSalesDataChart.ItemsSource = arrGraphData;
            #endregion
        }

        //Method for making request for 'GetStatewisesales' operations from the service
        private void LoadAndDIsplayStatewiseSales()
        {
            WebRequest myRequest = WebRequest.Create("http://localhost/WCF_Rest_WPF/CService.svc/GetStatewisesales");
            WebResponse myResponse = myRequest.GetResponse();
            DataContractSerializer RecData = new DataContractSerializer(typeof(List<clsDataContracts.clsStatewiseSales>));
            var CollectionStatewiseSales = RecData.ReadObject(myResponse.GetResponseStream());

            #region Code for putting 'CollectionStatewiseSales' in KeyValuePair
            //Convert the received object into the original collection
            List<clsDataContracts.clsStatewiseSales> lstStatewiseSales = (List<clsDataContracts.clsStatewiseSales>)CollectionStatewiseSales;

            //Set the size as the number of records in the received collection 
            KeyValuePair<string, decimal>[] arrGraphData = new KeyValuePair<string, decimal>[lstStatewiseSales.Count];

            int i = 0;
            foreach (var item in lstStatewiseSales)
            {
                arrGraphData[i] = new KeyValuePair<string, decimal>(item.StateName, item.SalesQuantity);
                i++;
            }

            chartStatewiseSalesColumn.DataContext = arrGraphData;
            pieStateSalesChart.ItemsSource = arrGraphData;
            #endregion

        }
    }
}
