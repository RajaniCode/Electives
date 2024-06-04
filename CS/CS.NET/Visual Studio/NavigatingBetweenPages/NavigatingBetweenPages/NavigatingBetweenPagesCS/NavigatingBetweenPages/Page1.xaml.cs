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

namespace NavigatingBetweenPages
{
    public partial class Page1 : UserControl
    {
        public Page1()
        {
            InitializeComponent();            
        }       

        private void btnPage2Go_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text != String.Empty)
            {
                App app = (App)Application.Current;
                app.UserName = txtUser.Text;
                app.GoToPage(new Page2());
            }
        }

      
    }
}
