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

namespace MyAutoCompleteBoxCS
{
    public partial class MainPage : UserControl
    {

        public MainPage()
        {
            InitializeComponent();
            List<string> cityNames = new List<string>();
            cityNames.Add("Arizona");
            cityNames.Add("Atlanta");
            cityNames.Add("California");
            cityNames.Add("Chicago");
            cityNames.Add("Colorado");
            cityNames.Add("Denver");
            cityNames.Add("Detroit");
            cityNames.Add("Durham");
            cityNames.Add("Florida");
            cityNames.Add("Georgia");
            cityNames.Add("Hamilton");
            cityNames.Add("Hampshire");
            cityNames.Add("Lancaster");
            cityNames.Add("Las Vegas");
            cityNames.Add("Los Angeles");
            cityNames.Add("Michigan");
            cityNames.Add("New Jersey");
            cityNames.Add("New Orleans");
            cityNames.Add("New York");
            cityNames.Add("North Carolina");
            cityNames.Add("Ohio");
            cityNames.Add("Olympia");
            cityNames.Add("San Diego");
            cityNames.Add("San Francisco");
            cityNames.Add("San Jose");
            cityNames.Add("Seattle");
            cityNames.Add("Washington");
            cityNames.Add("Texas");
            myACB.ItemsSource = cityNames;
        }
    }
}
