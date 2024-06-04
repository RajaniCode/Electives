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

using System.Messaging;
using System.Configuration;
using System.ServiceModel;

namespace WPF_WCFServiceHost
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ServiceHost Host;
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string qName = ConfigurationSettings.AppSettings["qName"].ToString();

            MessageQueue mq = null;
            if (!MessageQueue.Exists(qName))
            {
                mq = MessageQueue.Create(qName,true); 
            }

            Host = new ServiceHost(typeof(CService));
             Host.Open();

             txtRecMessages.Text += qName; 
 
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Host.Close();
        }
    }
}
