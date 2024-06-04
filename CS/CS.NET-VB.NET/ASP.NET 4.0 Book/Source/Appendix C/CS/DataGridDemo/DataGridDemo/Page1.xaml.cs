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

namespace DataGridDemo
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            dataGrid1.Items.Add("Tim");
            dataGrid1.Items.Add("Jack");
            dataGrid1.Columns.Add(new DataGridTextColumn());
            DataGridTextColumn col1 = new DataGridTextColumn();
            dataGrid1.Columns.Add(col1);
            col1.Binding = new Binding(".");
            col1.Header = "Name";
        }
    }
}
