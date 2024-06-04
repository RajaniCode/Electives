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
using Microsoft.Phone.Controls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace WP7_GettingDataFromWCFService
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                WebClient wClient = new WebClient();
                wClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wClient_DownloadStringCompleted);
                wClient.DownloadStringAsync(new Uri("http://maheshserver.mossserver.com:8900/REST_SL4_DML/Service.svc/GetAllEmployee", UriKind.Absolute)); 
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        void wClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

                XDocument xDoc = XDocument.Parse(e.Result);

                var AllEmps = from Emp in xDoc.Descendants("Employee")
                              select new Employee()
                              {
                                  EmpNo = Convert.ToInt32(Emp.Descendants("EmpNo").First().Value),
                                  EmpName = Emp.Descendants("EmpName").First().Value,
                                  Salary = Convert.ToInt32(Emp.Descendants("Salary").First().Value),
                                  DeptNo = Convert.ToInt32(Emp.Descendants("DeptNo").First().Value)
                              };

                lstEmpDetails.DataContext = AllEmps.ToList();
                lstEmpDetails.ItemsSource = AllEmps.ToList();

             

                 
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }

        }
    }
}