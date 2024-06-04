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
using System.Windows.Messaging;

namespace SILV3_DataPresenter
{
    public partial class MainPage : UserControl
    {

        LocalMessageReceiver dataReceiver;

        public MainPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PatientCollection patientRecord = new PatientCollection ();
            dgData.ItemsSource = patientRecord;

            //Attach REceiver with Sender
            dataReceiver = new LocalMessageReceiver("DataToFilter");
 
            //Now receive the MEssage
            dataReceiver.MessageReceived += (strData, evt) =>
                {
                    //Process the received data
                    Dispatcher.BeginInvoke(() =>
                        {
                            var filteredData = from patient in patientRecord
                                               where patient.PatientName.StartsWith(evt.Message)
                                               select patient;

                            dgData.ItemsSource = filteredData;
                        });
                };

            //Listen the Message Received, this does not block the thread
            dataReceiver.Listen(); 
        }
    }
}
