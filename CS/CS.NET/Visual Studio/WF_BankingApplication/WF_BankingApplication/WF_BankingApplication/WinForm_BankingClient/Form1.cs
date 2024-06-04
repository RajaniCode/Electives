using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Activities;
using System.Threading; 



namespace WinForm_BankingClient
{
    public partial class Form1 : Form
    {
 

        Dictionary<string, object> param;
        WorkflowInstance wInstance;
        AutoResetEvent waitHandle;

        decimal NetBalance = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                waitHandle = new AutoResetEvent(false); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void btnPerformTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                param = new Dictionary<string, object>();
                param.Add("AccountName", txtaccname.Text);
                param.Add("AccountAddress", txtaccaddress.Text);
                param.Add("OpeningBalance", Convert.ToDecimal(txtopeningbalance.Text));
                if (rdDeposit.Checked)
                {
                    param.Add("TransactionType", rdDeposit.Text);
                }
                if (rdWithdrawal.Checked)
                {
                    param.Add("TransactionType", rdWithdrawal.Text);
                }
                param.Add("TransactionAmount", Convert.ToDecimal(txttranamount.Text));

                wInstance = new WorkflowInstance(new WF_BankingApplication.WF_BankingApp(), param);

                wInstance.OnCompleted = delegate(WorkflowCompletedEventArgs evt)
                {
                    NetBalance = Convert.ToDecimal(evt.Outputs["NetBalance"]);
                    waitHandle.Set();
                };

                wInstance.Run(); 

                waitHandle.WaitOne();

                txtnetbalance.Text = NetBalance.ToString(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
