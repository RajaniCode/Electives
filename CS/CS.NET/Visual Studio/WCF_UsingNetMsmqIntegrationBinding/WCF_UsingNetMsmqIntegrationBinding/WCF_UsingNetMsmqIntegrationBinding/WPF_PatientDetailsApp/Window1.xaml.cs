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
using BusinessDataObject;
using System.Collections.ObjectModel;
using System.Diagnostics; 
namespace WPF_PatientDetailsApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnection Conn;
        SqlDataAdapter AdPatientMaster;
        DataSet Ds;

        ObservableCollection<PatientMaster> CollectionPatients = new ObservableCollection<PatientMaster>();
        public Window1()
        {
            InitializeComponent();
        }

        private void btnLoadPatientInfo_Click(object sender, RoutedEventArgs e)
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Medical;Integrated Security=SSPI");
            AdPatientMaster = new SqlDataAdapter("Select * from PatientMaster",Conn);
            Ds = new DataSet();
            AdPatientMaster.Fill(Ds,"PatientMaster");

            DataRowCollection DrCPatient = Ds.Tables["PatientMaster"].Rows;
            CollectionPatients.Clear();  

            foreach (DataRow Dr in DrCPatient)
            {
                CollectionPatients.Add
                    (
                      new PatientMaster()
                         {
                             PatientId = Convert.ToInt32(Dr["PitientId"]),
                             PatientName = Dr["PatientName"].ToString(),
                             PatientAddress = Dr["PatientAddress"].ToString(),
                             PatientAge = Convert.ToInt32(Dr["PatientAge"])
                         }
                    );
            }

            dgPatient.ItemsSource = CollectionPatients;
 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("There are Some More Patients Pending, please wait for some time and click on Load button");  

        }
    }
}
