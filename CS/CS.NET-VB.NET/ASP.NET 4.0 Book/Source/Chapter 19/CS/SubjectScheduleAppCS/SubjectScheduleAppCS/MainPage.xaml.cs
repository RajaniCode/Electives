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

namespace SubjectScheduleAppCS
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            DateTime firstDay = new DateTime(2010, 8, 1);
            DateTime endDay = firstDay.AddDays(15);
            //specifying the first visible and selectable date 
            bioDate.DisplayDateStart = firstDay;
            chemDate.DisplayDateStart = firstDay;
            engDate.DisplayDateStart = firstDay;
            finDate.DisplayDateStart = firstDay;
            mathDate.DisplayDateStart = firstDay;
            phyDate.DisplayDateStart = firstDay;
            //specifying the last visible and selectable date
            bioDate.DisplayDateEnd = endDay;
            chemDate.DisplayDateEnd = endDay;
            engDate.DisplayDateEnd = endDay;
            finDate.DisplayDateEnd = endDay;
            mathDate.DisplayDateEnd = endDay;
            phyDate.DisplayDateEnd = endDay;

        }
    }
}