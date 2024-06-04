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

namespace WPF_ADONET_EF_Commanding
{
    /// <summary>
    /// Interaction logic for AllEmployeesView.xaml
    /// </summary>
    public partial class AllEmployeesView : UserControl
    {
        public AllEmployeesView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(AllEmployeesView_Loaded);
        }

        void AllEmployeesView_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
