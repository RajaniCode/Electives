using System.Windows.Controls;
using SilverlightApplication1.Web;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        private void filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            parent.DataContext = filter.SelectedItem as Customers;
        }
    }
}
