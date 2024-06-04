using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;

namespace SILV3_DynamicLoadingResourceDictionary
{
    public partial class MainPage : UserControl
    {

        ResourceDictionary rd1, rd2;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.Window.Alert("Button One"); 
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            rd1 = new ResourceDictionary();
            rd1.Source = new Uri("ButtonStyles.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd1);
            System.Windows.Style btnStyle = rd1["btnKey"] as Style;
            btnOne.Style = btnStyle;

            rd2 = new ResourceDictionary();

            rd2.Source = new Uri(@"/SILV3_ExternalResourceDictionary;component/ExternalButtonStyle.xaml",UriKind.Relative);
            this.Resources.MergedDictionaries.Add(rd2);

            System.Windows.Style btnStyle1 = rd2["btnExternslStyle"] as Style;

            btnTwo.Style = btnStyle1;
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.Window.Alert("Button Two"); 
        }
    }
}
