using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Mobile_Client_Of_WCFREST
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            frmGetAll frmAll = new frmGetAll();
            frmAll.Show();
        }

        private void btnDML_Click(object sender, EventArgs e)
        {
            frmDMLOperations frmDml = new frmDMLOperations();
            frmDml.Show();
        }
    }
}