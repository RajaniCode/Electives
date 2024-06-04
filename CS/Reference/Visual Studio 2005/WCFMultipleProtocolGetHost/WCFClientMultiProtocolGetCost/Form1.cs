using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WCFSampleGetCost;
namespace WFCClientGetCost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstMultiProtocol.Items.Add("IServiceGetCost");
            lstMultiProtocol.Items.Add("IServiceGetCost1");
        }

        private void lstMultiProtocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            productData objproductData = new productData();
            string strProtocol;
            objproductData.costPerProduct = 100;
            objproductData.Qty = 4;
            objproductData.strProductName = "Tooth Paste";
            ServiceGetCostProxy objServiceGetCostProxy;
            strProtocol = lstMultiProtocol.SelectedItem.ToString();
            objServiceGetCostProxy=new ServiceGetCostProxy(strProtocol);

            MessageBox.Show(objServiceGetCostProxy.GetTotalCost(objproductData));
        }
    }
}