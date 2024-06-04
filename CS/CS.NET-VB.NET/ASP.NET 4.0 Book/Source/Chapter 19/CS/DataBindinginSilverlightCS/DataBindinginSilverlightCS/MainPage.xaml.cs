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

namespace DataBindinginSilverlightCS
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.MyServiceClient sc = new DataBindinginSilverlightCS.ServiceReference1.MyServiceClient();
            sc.GetByLastNameCompleted += new EventHandler<DataBindinginSilverlightCS.ServiceReference1.GetByLastNameCompletedEventArgs>(sc_GetByLastNameCompleted);
            sc.GetByLastNameAsync(DataEntry.Text);
        }

        void sc_GetByLastNameCompleted(object sender, DataBindinginSilverlightCS.ServiceReference1.GetByLastNameCompletedEventArgs e)
        {
            DataGrid.ItemsSource = e.Result;
        }
    }
}
