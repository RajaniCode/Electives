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
using System.IO;
using System.Windows.Media.Imaging;


namespace Weather
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;

        }

        private void LstCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem currentCity = LstCity.SelectedItem as ListBoxItem;
            txtCity.Text = currentCity.Content.ToString();
            string strWOEID = string.Empty;
            switch (txtCity.Text)
            {
                case "Trivandrum" :
                    strWOEID = "2295426";
                    break;
                case "Bangalore":
                    strWOEID = "2295420";
                    break;
                case "Chennai":
                    strWOEID = "2295424";
                    break;
                case "Cochin":
                    strWOEID = "2295423";
                    break;
                case "Delhi":
                    strWOEID = "20070458";
                    break;
                case "Pune":
                    strWOEID = "2295412";
                    break;
                case "Kolkata":
                    strWOEID = "2295386";
                    break;
                case "Hyderabad":
                    strWOEID = "2295414";
                    break;
                case "Visakhapatnam":
                    strWOEID = "2295418";
                    break;
                case "Mumbai":
                    strWOEID = "2295411";
                    break;
            }

            GetTodaysWeather(strWOEID);
        }

        private void GetTodaysWeather(string strWOEID)
        {
            try
            {
                Uri url = new Uri("http://weather.yahooapis.com/forecastrss?w=" + strWOEID + "&u=c");
                WebClient client = new WebClient();
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
                client.DownloadStringAsync(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                StringReader stream = new StringReader(e.Result);
                XmlReader reader = XmlReader.Create(stream);
                reader.ReadToFollowing("yweather:condition");
                //Populate Temperature
                reader.MoveToAttribute("temp");
                txtWeather.Text = reader.Value;

                //Set Image based on the code
                reader.MoveToAttribute("code");
                Uri url;
                url = new Uri("http://l.yimg.com/a/i/us/nws/weather/gr/" + reader.Value + "d.png");

                BitmapImage img = new BitmapImage(url);
                imgWeather.Source = new BitmapImage(url);

                //Forecast

                reader.ReadToFollowing("yweather:forecast");
                reader.MoveToAttribute("day");
                txtDay1.Text = reader.Value;
                reader.MoveToAttribute("low");
                txtDay1.Text += " Low: " + reader.Value;
                reader.MoveToAttribute("high");
                txtDay1.Text += " High: " + reader.Value;

                reader.ReadToNextSibling("yweather:forecast");
                reader.MoveToAttribute("day");
                txtDay2.Text = reader.Value;
                reader.MoveToAttribute("low");
                txtDay2.Text += " Low: " + reader.Value;
                reader.MoveToAttribute("high");
                txtDay2.Text += " High: " + reader.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}