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


using System.Net;
using System.Windows.Browser;


namespace SILV4_NetworkClientAuthentication
{
    public partial class MainPage : UserControl
    {

 
 
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGetNames_Click(object sender, RoutedEventArgs e)
        {
            WebRequest.RegisterPrefix("http://", System.Net.Browser.WebRequestCreator.ClientHttp);

            WebClient wc = new  WebClient();
             
            wc.Credentials = new NetworkCredential(txtUname.Text, txtPassword.Password);
            wc.UseDefaultCredentials = false;

            wc.DownloadStringCompleted += new System.Net.DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);

            wc.DownloadStringAsync(new Uri("http://localhost:8900/SILV40_WCF_Nw_Auth/Service.svc/GetNames"));  
        }

        void wc_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    txtdata.Text = e.Result;
                }
            }
            catch (Exception ex)
            {
                ExceptionWindow exWind = new ExceptionWindow(ex.Message + "There is a Problem is request, Please check User Name or Password");
                exWind.Show(); 
            }
        }
    }
}
