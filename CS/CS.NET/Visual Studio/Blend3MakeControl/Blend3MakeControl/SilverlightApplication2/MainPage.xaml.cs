using System.Windows.Controls;

namespace SilverlightApplication2
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Browser.HtmlPage.Window.Invoke("HelloWorld", new string[] { "Hi there!" });
        }
    }
}
