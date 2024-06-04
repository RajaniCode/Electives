using System.Windows;
using System.Windows.Controls;
using System.Windows.Printing;

namespace PrintingSilverlight
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument pdoc = new PrintDocument();
            pdoc.PrintPage += (p, args) => {
                args.PageVisual = imgOne;
                args.HasMorePages = false;

            };

            pdoc.EndPrint += (p, args) =>
            {
                MessageBox.Show("Printing operation completed");
            };

            pdoc.Print("Some Document");
        }

    }
}
