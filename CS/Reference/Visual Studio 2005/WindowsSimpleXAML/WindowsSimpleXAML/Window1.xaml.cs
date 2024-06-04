using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace WindowsSimpleXAML
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        void MyClickEvent(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello you are inside the code");
        }
        public Window1()
        {
            InitializeComponent();
        }

    }
}