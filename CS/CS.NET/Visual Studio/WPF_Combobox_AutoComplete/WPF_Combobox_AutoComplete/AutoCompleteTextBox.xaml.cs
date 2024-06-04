using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace WPF_Combobox_AutoComplete
{
    /// <summary>
    /// Interaction logic for AutoCompleteTextBox.xaml
    /// </summary>
    public partial class AutoCompleteTextBox : UserControl
    {
        public AutoCompleteTextBox()
        {
            InitializeComponent();
            txtAutoComplete.TextChanged += new TextChangedEventHandler(txtAutoComplete_TextChanged); 
        }

        void txtAutoComplete_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = true;
            TextToChanged = txtAutoComplete.Text;
            RoutedEventArgs args = new RoutedEventArgs(TextBoxContentChangedEvent);
            RaiseEvent(args); 
        }


        public string TextToChanged
        {
            get { return (string)GetValue(TextToChangedProperty); }
            set { SetValue(TextToChangedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextToChanged.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextToChangedProperty =
            DependencyProperty.Register("TextToChanged", typeof(string), typeof(AutoCompleteTextBox));

        public IEnumerable DataSource
        {
            get { return (IEnumerable)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof(IEnumerable), typeof(AutoCompleteTextBox));

        public event RoutedEventHandler TextBoxContentChanged 
        {
            add { AddHandler(TextBoxContentChangedEvent, value); }
            remove { RemoveHandler(TextBoxContentChangedEvent, value); }
        }
        public static readonly RoutedEvent TextBoxContentChangedEvent = 
            EventManager.RegisterRoutedEvent("TextBoxContentChanged", RoutingStrategy.Bubble,
            typeof(RoutedEventHandler), typeof(AutoCompleteTextBox));    
    }
}
