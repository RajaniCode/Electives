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

namespace WPF_Combobox_AutoComplete
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<string> lstNames;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstNames = new List<string>();
          
        }
        private void ListData()
        {
            lstNames.Add("");
            lstNames.Add("Ajay");
            lstNames.Add("Rahul");
            lstNames.Add("Rajesh");
            lstNames.Add("Ravi");
            lstNames.Add("Suprotim");
            lstNames.Add("Ajit");
            lstNames.Add("Suraj");
            lstNames.Add("Vikram");
            lstNames.Add("Vikas");
            lstNames.Add("Pravin");
            lstNames.Add("Suprabhat");
            txtAutoCompleteTextBox.DataSource = lstNames; ;
        }

        private void txtAutoCompleteTextBox_TextBoxContentChanged(object sender, RoutedEventArgs e)
        {
                ListData();
                string s = txtAutoCompleteTextBox.TextToChanged;
                var filter = (from name in lstNames
                              where (name.Contains(s))
                              select name).ToList<string>();
                foreach (var item in filter)
                {
                    if (item.Equals(s))
                    {
                        txtAutoCompleteTextBox.TextToChanged = s;
                    }
                }

                 txtAutoCompleteTextBox.DataSource = filter;

                 if (s == string.Empty)
                 {
                     filter.Clear();
                     txtAutoCompleteTextBox.DataSource = filter;
                 }
             
            
        }
    }
}
