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

namespace CalendarDemoCS
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            SetDisplayDates();
        }
        private void SetDisplayDates()
        {
            myCal1.DisplayDate = new DateTime(2010, 5, 1);
            myCal1.DisplayDateStart = new DateTime(2010, 5, 1);
            myCal1.DisplayDateEnd = new DateTime(2010, 8, 31);  
        }

        private void myCal1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
                MessageBox.Show("You selected: " + myCal1.SelectedDate.ToString());
            }
        }
    }
