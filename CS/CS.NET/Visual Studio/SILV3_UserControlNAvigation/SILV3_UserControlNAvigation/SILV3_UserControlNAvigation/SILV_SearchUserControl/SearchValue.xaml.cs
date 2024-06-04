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

namespace SILV_SearchUserControl
{
    public partial class SearchValue : UserControl
    {
        public SearchValue()
        {
            InitializeComponent();
        }


        public string strData
        {
            get { return (string)GetValue(strDataProperty); }
            set { SetValue(strDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for strData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty strDataProperty =
            DependencyProperty.Register("strData", typeof(string), typeof(SearchValue), new PropertyMetadata(""));

       //Define Delegate and Events

        public delegate void TextValueChangedEventHandler(object s, EventArgs e);

        public event TextChangedEventHandler TextBoxChanged;
        
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            strData = txtSearch.Text;
           
            if (TextBoxChanged != null)
            {
                TextBoxChanged(this, e); 
            }
        }
    }
}
