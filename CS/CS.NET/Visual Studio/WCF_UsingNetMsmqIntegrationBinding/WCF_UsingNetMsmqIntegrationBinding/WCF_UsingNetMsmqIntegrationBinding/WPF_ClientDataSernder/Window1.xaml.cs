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

using BusinessDataObject;
using System.Messaging;
using System.Configuration;
using System.Transactions; 

namespace WPF_ClientDataSernder
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        PatientMaster objPatient;
        public Window1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageQueue patientQueue;
            try
            {
                string qName  = ConfigurationSettings.AppSettings["qName"].ToString ();
                patientQueue = new MessageQueue(@"FormatName:Direct=OS:" + qName);

                //Store Patient Information

                Message patientMessage = new Message();

                patientMessage.Body = objPatient;
                patientMessage.Label = "PatientInfo"; 

                //Now Create Transaction Scope

                using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required))
                {
                    patientQueue.Send(patientMessage, MessageQueueTransactionType.Automatic);
                    tran.Complete();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            objPatient = new PatientMaster();
            this.DataContext = objPatient;
        }
    }
}
