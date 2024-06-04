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
using System.Xml.Linq;

namespace SILV4_WCFRESTClient
{
    public partial class MainPage : UserControl
    {
        WebClient webClient;
        public MainPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri("http://maheshserver.mossserver.com:8900/REST_SL4_DML/Service.svc/GetAllEmployee", UriKind.Absolute));  
        }

        void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
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
              dgEmp.DataContext = AllEmps.ToList();
              dgEmp.ItemsSource = AllEmps.ToList();  
         
        }
    }
}
