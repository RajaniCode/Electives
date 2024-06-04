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
using System.Threading;

namespace WPFXbapApp
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FormattedText text = new FormattedText("KOGENT SOLUTIONS!", Thread.CurrentThread.CurrentUICulture, FlowDirection.LeftToRight, new
              Typeface("Arial Black"), 10, Brushes.Black);
            Geometry textGeometry = text.BuildGeometry(new Point(0, 0));
            button1.Clip = textGeometry;
        }
    }
}
