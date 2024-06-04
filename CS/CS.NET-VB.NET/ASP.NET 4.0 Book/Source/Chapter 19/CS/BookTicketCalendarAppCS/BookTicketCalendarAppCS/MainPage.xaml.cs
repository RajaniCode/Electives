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

namespace BookTicketCalendarAppCS
{
    public partial class MainPage : UserControl
    {
        private Boolean checkTicket;    
        public MainPage()
        {
            InitializeComponent();
            checkTicket = true;
            text2.Text = "Today is " + DateTime.Now;
            toIconButton.IsEnabled = false;
            selectIconButton.IsEnabled = false;
            fromCal.Visibility = Visibility.Collapsed;
            toCal.Visibility = Visibility.Collapsed;
            selectCal.Visibility = Visibility.Collapsed;
        }
        private void fromIconClick(object sender, RoutedEventArgs e)
        {
            fromCal.Visibility = Visibility.Visible;
            fromCal.DisplayDateStart = new DateTime(2010, 1, 1);
            fromCal.DisplayDateEnd = new DateTime(2011, 12, 31);
        }

        private void fromCalDateSelected(object sender, SelectionChangedEventArgs e)
        {
            fromDateBox.Text = fromCal.SelectedDate.ToString();
            fromCal.Visibility = Visibility.Collapsed;
            toIconButton.IsEnabled = true;
        }

        private void toIconClick(object sender, RoutedEventArgs e)
        {
            toCal.Visibility = Visibility.Visible;
            toCal.DisplayDateStart = fromCal.SelectedDate;
            toCal.DisplayDateEnd = fromCal.DisplayDateEnd;
        }

        private void toCalDateSelected(object sender, SelectionChangedEventArgs e)
        {
            toDateBox.Text = toCal.SelectedDate.ToString();
            toCal.Visibility = Visibility.Collapsed;
            checkAvailibility.IsEnabled = true;
        }

        private void isTicketAvailable(object sender, RoutedEventArgs e)
        {
            if (checkTicket == true)
                selectIconButton.IsEnabled = true;
        }

        private void selectIconClick(object sender, RoutedEventArgs e)
        {
            selectCal.Visibility = Visibility.Visible;
            selectCal.DisplayDateStart = fromCal.SelectedDate;
            selectCal.DisplayDateEnd = toCal.SelectedDate;
        }

        private void selectCalDateSelected(object sender, SelectionChangedEventArgs e)
        {
            selectDateBox.Text = selectCal.SelectedDate.ToString();
            selectCal.Visibility = Visibility.Collapsed;
            confirmButton.IsEnabled = true;
        }

        private void confirmBooking(object sender, RoutedEventArgs e)
        {
            text3.Opacity = 0;
            text4.Opacity = 0;
            text5.Opacity = 0;
            text6.Opacity = 0;
            fromDateBox.Opacity = 0;
            fromIconButton.Opacity = 0;
            toDateBox.Opacity = 0;
            toIconButton.Opacity = 0;
            selectDateBox.Opacity = 0;
            selectIconButton.Opacity = 0;
            checkAvailibility.Opacity = 0;
            confirmButton.Opacity = 0;
            text1.Text = "Thank You";
        }
    }
}


