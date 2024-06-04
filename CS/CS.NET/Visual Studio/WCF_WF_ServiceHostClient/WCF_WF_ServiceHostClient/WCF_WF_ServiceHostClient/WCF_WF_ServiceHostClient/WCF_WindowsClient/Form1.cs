using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WCF_WindowsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void brnGetData_Click(object sender, EventArgs e)
        {
            MyRef.clsInput objIn = new WCF_WindowsClient.MyRef.clsInput();

            objIn.DbName = txtdbname.Text;
            objIn.TbName = txttbname.Text;

            MyRef.clsOutput objOut = new WCF_WindowsClient.MyRef.clsOutput();

            MyRef.ServiceClient Proxy = new WCF_WindowsClient.MyRef.ServiceClient();

            objOut = Proxy.GetData(objIn);

            dgdata.DataSource = objOut.Ds.Tables[txttbname.Text];
        }
    }
}
