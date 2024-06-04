using System.Collections.Generic;
using System.Windows.Browser;
using System.Windows.Controls;

namespace SilverlightApplication1
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();
            BindQueryString();
        }
        
        public void BindQueryString()
        {
            cboQueryString.ItemsSource = HtmlPage.Document.QueryString;
            cboQueryString.SelectedIndex = 0;
        }       
    }
}
