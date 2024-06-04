using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace WindowsAllXAML
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            objText = new TextBlock();
        }

        private void ChangeValue(object sender, EventArgs e)
        {
            objText.Text = "I am trying to learn XAML";
        }

        private void ChangeValue1(object sender, EventArgs e)
        {
            objText.Text = "XAML is easy to learn";
        }
    }
}