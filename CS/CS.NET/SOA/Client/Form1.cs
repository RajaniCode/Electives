using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            try
            {
                button1.Enabled = false;
                label1.Text = "Calling service...";
                
                // this allows the above label to be updated before waiting on the proxy call.
                Application.DoEvents();

                // create the proxy to the service. a proxy is a "reference" to the service.
                // it allows us to make a call to the service as though it were present
                // locally even though it could be on the same machine or on a different
                // machine.
                ServiceReference1.RandomDelayServiceClient proxy = new Client.ServiceReference1.RandomDelayServiceClient();

                // call the service method
                result = proxy.RandomDelay();
            }
            catch (Exception exception)
            {
                result = "An error occurred.";
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                label1.Text = result;
                button1.Enabled = true;
            }
        }
    }
}
