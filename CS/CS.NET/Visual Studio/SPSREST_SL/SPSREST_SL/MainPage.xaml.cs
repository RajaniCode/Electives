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
using SPSREST_SL.PurchaseOrderProxy;
using System.Collections.ObjectModel;
using System.Data.Services.Client;
using Microsoft.CSharp;
using System.Runtime.InteropServices.Automation;


namespace SPSREST_SL
{
    public partial class MainPage : UserControl
    {
        private readonly string customersSiteURL = "/sites/PurchOrd/";
        private readonly string listService = "_vti_bin/listdata.svc";
        private readonly ObservableCollection<CustomersItem> allCustomers = new ObservableCollection<CustomersItem>();
        public MainPage()
        {
            InitializeComponent();
            Uri appSource = App.Current.Host.Source;
            string fullPartsSiteUrl = string.Format("{0}://{1}:{2}{3}{4}", appSource.Scheme, appSource.Host, appSource.Port, customersSiteURL, listService);
            this.DataContext = new PurchaseOrderSiteDataContext(new Uri(fullPartsSiteUrl));

            lstAllCustomers.ItemsSource = allCustomers;
            //dgCustomersList.ItemsSource = allCustomers;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            GetAllCustomers(txtCountry.Text);
        }

        public void GetAllCustomers(string Country)
        {
            allCustomers.Clear();
            var context = (PurchaseOrderSiteDataContext)this.DataContext;
            //Define Query
            var query = (DataServiceQuery<CustomersItem>)context.Customers
                                                                .Where(p => p.Country.StartsWith(Country))
                                                                .Select(p => new CustomersItem
                                                                {
                                                                    CustomerID = p.CustomerID,
                                                                    CustomerName = p.CustomerName,
                                                                    City = p.City
                                                                });

            //Execute Query
            query.BeginExecute(DisplayAllCustomers, query);
        }

        private void DisplayAllCustomers(IAsyncResult result)
        {
            Dispatcher.BeginInvoke(() =>
            {
                DataServiceQuery<CustomersItem> query = (DataServiceQuery<CustomersItem>)result.AsyncState;
                var partResults = query.EndExecute(result);

                foreach (var part in partResults)
                {
                    allCustomers.Add(part);
                }
            });

        }

        private void btnOOB_Click(object sender, RoutedEventArgs e)
        {
            var excel = AutomationFactory.CreateObject("Excel.Application");
            excel.Visible = true;
            var workbook = excel.workbooks;
            workbook.Add();

            var sheet = excel.ActiveSheet;
            dynamic cell = null;

            int excelRow = 1;

            foreach (CustomersItem customer in allCustomers)
            {
                cell = excel.Cells[excelRow, 1];
                cell.Value = customer.CustomerID;
                cell.ColumnWidth = 25;

                cell = excel.Cells[excelRow, 2];
                cell.Value = customer.CustomerName;
                cell.ColumnWidth = 25;

                cell = excel.Cells[excelRow, 3];
                cell.Value = customer.City;
                cell.ColumnWidth = 25;

                cell = excel.Cells[excelRow, 4];
                cell.Value = customer.Country;
                cell.ColumnWidth = 25;

                excelRow++;
            }


        }
    }
}
