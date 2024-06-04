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

namespace SILV3_DataFilter
{
    public partial class MainPage : UserControl
    {
        LocalMessageSender dataSender = new LocalMessageSender("DataToFilter");

        public MainPage()
        {
            InitializeComponent();
        }

        private void txtData_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Provides the data for messaging
            EventHandler<SendCompletedEventArgs> senderHandler = null;

            senderHandler =
                (strData, evt) =>
                {
                    Dispatcher.BeginInvoke(() =>
                        {
                            dataSender.SendCompleted -= senderHandler;  
                        });

                };

            dataSender.SendCompleted += senderHandler;

            //Start Asynchronous Messag Sending
            dataSender.SendAsync(txtData.Text);
 
        }

    }
}
