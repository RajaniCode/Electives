using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SilverlightRightMouseClick
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();           

            tb.MouseRightButtonDown += new MouseButtonEventHandler(tb_MouseRightButtonDown);
            tb.MouseRightButtonUp += new MouseButtonEventHandler(tb_MouseRightButtonUp);
        }


        void tb_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            cm.HorizontalOffset = e.GetPosition(tb).X + 2;
            cm.VerticalOffset = e.GetPosition(tb).Y + 2;
            cm.IsOpen = true;
        }

        void tb_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            switch (menuItem.Header.ToString())
            {
                case "Cut":
                    Clipboard.SetText(tb.SelectedText);
                    tb.SelectedText = "";
                    tb.Focus();
                    break;
                case "Copy":
                    Clipboard.SetText(tb.SelectedText);
                    tb.Focus();            
                    break;
                case "Paste":
                    tb.SelectedText = Clipboard.GetText();
                    break;
                default:
                    break;
            }
            cm.IsOpen = false;
        }
    }
}
