using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win_WorkflowWCFService
{
    public partial class Form1 : Form
    {
        MyRef.ServiceClient Proxy;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetAllEmp_Click(object sender, EventArgs e)
        {
            Proxy = new MyRef.ServiceClient();
            dgEmp.DataSource = Proxy.GetAllEmp(); 
        }
    }
}
