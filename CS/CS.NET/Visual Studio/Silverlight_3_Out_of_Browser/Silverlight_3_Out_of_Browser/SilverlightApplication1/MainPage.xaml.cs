using System.Windows;
using System.Windows.Controls;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            switch (Application.Current.InstallState) 
            {
                case InstallState.NotInstalled:
                    txtOutofBrowser.Text = "Running in browser";
                    break;
                case InstallState.Installed:
                    txtOutofBrowser.Text = "Installed locally";
                    break;
            }            
        }
    }
}
