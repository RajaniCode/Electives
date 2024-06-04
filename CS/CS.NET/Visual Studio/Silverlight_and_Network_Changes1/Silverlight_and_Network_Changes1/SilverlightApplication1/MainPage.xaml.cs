using System;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        private bool Online { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetNetworkStatus();
            NetworkChange.NetworkAddressChanged += new 
                NetworkAddressChangedEventHandler(NetworkChange_NetworkAddressChanged);
        }

        void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            GetNetworkStatus();
        }

        private void GetNetworkStatus()
        {
            Online = NetworkInterface.GetIsNetworkAvailable();
            txtNetwork.Text = Online ? "Online" : "Offline...";
            SolidColorBrush scb = new SolidColorBrush(Online ? Colors.Yellow : Colors.Red);
            NetworkStatus.Background = scb;
        }
    }
}
