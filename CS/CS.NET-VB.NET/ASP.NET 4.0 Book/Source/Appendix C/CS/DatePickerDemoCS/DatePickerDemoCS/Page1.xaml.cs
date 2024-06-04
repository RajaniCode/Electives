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

namespace DatePickerDemoCS
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
            myDP.DisplayDate = new DateTime(2010, 6, 1);
            myDP.DisplayDateStart = new DateTime(2010, 6, 1);
            myDP.DisplayDateEnd = new DateTime(2010, 6, 30);
            myDP.FirstDayOfWeek = DayOfWeek.Tuesday;
        }
    }
}
