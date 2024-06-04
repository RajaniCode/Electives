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

namespace PopUpHelpAppCS
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void showTextPopup(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = true;
        }
        public void showListPopup(object sender, RoutedEventArgs e)
        {
            popup2.IsOpen = true;
        }
        public void showCalendarPopup(object sender, RoutedEventArgs e)
        {
            popup3.IsOpen = true;
        }
        public void hideTextPopup(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = false;
        }
        public void hideListPopup(object sender, RoutedEventArgs e)
        {
            popup2.IsOpen = false;
        }
        public void hideCalendarPopup(object sender, RoutedEventArgs e)
        {
            popup3.IsOpen = false;
        }
    }
}
