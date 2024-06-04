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

namespace WinForm_WFTransactionClient
{
    public partial class Form1 : Form
    {

        AutoResetEvent waitHandle;
        WorkflowInstance instance;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaveDetails_Click(object sender, EventArgs e)
        {

            Dictionary<string, object> Par = new Dictionary<string, object>();
            Par.Add("billNo",Convert.ToInt32(txtbillno.Text) );
            Par.Add("patientId", Convert.ToInt32(txtpatid.Text));
            Par.Add("patientName",txtpatname.Text ); 
            Par.Add("billAmount",Convert.ToInt32(txtbillamt.Text ) );
            Par.Add("claimId", Convert.ToInt32(txtclaimid.Text));
            Par.Add("policyNo", Convert.ToInt32(txtpolictno.Text));
            Par.Add("policyAmount", Convert.ToInt32(txtpolicyamt.Text));
            Par.Add("claimAmount", Convert.ToInt32(txtclaimamt.Text));

            instance = new WorkflowInstance(new WF_TransactionScope.WF_TransactionScopeSequence(),Par);

            instance.OnCompleted = delegate(WorkflowCompletedEventArgs e1) { waitHandle.Set(); };

            instance.OnUnhandledException = delegate(WorkflowUnhandledExceptionEventArgs e2)
            {
               MessageBox.Show(e2.UnhandledException.ToString());
                return UnhandledExceptionAction.Terminate;
            };
            instance.OnAborted = delegate(WorkflowAbortedEventArgs e3)
            {
                MessageBox.Show(e3.Reason.ToString());
                waitHandle.Set();
            };

            instance.Run();
            waitHandle.WaitOne(); 

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            waitHandle = new AutoResetEvent(false); 
        }

        private void txtpatname_TextChanged(object sender, EventArgs e)
        {
              txtpatname_1.Text = txtpatname.Text;
        }

        private void txtbillamt_TextChanged(object sender, EventArgs e)
        {
            txtclaimamt.Text = txtbillamt.Text;
        }
    }
}
