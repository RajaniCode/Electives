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

namespace BindingtoCLRObjectCS
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Data name1 = new Data();
        public Page1()
        {
            InitializeComponent();
            nameGrid.DataContext = name1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = name1.EmployeeID;
            string caption = name1.Name;
            MessageBox.Show(message, caption);
        }
    }
}
