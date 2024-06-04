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

namespace NavigatingBetweenPages
{
    public partial class Page2 : UserControl
    {
        App app = null;

        public Page2()
        {
            InitializeComponent();
            app = (App)Application.Current;
            lblDisplay.Text = lblDisplay.Text + " " + app.UserName;
        }

       
        private void btnPage1Go_Click(object sender, RoutedEventArgs e)
        {            
            app.GoToPage(new Page1());
        }
    }
}
