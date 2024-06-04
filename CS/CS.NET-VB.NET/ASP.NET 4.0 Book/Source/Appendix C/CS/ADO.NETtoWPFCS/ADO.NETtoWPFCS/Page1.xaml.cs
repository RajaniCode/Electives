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
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ADO.NETtoWPFCS
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
		{
			SqlConnection mycon = new SqlConnection();
			SqlDataAdapter myadapter = new SqlDataAdapter();
			SqlCommand cmd = new SqlCommand();
			String dataquery = "SELECT EmployeeID, FirstName, LastName,  City, Country FROM Employees";
			cmd.CommandText = dataquery;
			myadapter.SelectCommand = cmd;
			mycon.ConnectionString = "Data Source=ANAMIKA-PC\\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=True";
			cmd.Connection = mycon;
			DataSet ds = new DataSet();
			myadapter.Fill(ds);
			ListViewEmployeeDetails.DataContext = ds.Tables[0].DefaultView;
			mycon.Close();
		}
    }
}
