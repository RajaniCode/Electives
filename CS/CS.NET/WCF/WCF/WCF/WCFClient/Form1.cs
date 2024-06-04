using System;
using System.Windows.Forms;
using System.ServiceModel;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                WCFSampleServiceClient Client = new WCFSampleServiceClient();
                MessageBox.Show(Client.GetData(textBox1.Text.Trim()));
            }
            catch (FaultException fe)
            {
                MessageBox.Show(fe.Message);
            }
        }
    }
}
