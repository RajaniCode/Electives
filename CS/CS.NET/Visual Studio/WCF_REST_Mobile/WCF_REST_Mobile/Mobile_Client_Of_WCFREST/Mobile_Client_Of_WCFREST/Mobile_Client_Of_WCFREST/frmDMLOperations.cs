using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Mobile_Client_Of_WCFREST
{
    public partial class frmDMLOperations : Form
    {
        public frmDMLOperations()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string uploadUrl = "http://mahesh-pc/RESTVDDML/Service.svc/CreateEmployee/" + txteno.Text + "/" + txtename.Text + "/" + txtsal.Text + "/" + txtdno.Text;
                WebRequest addRequest = WebRequest.Create(uploadUrl);
                addRequest.Method = "POST";
                addRequest.ContentLength = 0;
                WebResponse addResponse = addRequest.GetResponse();

                MessageBox.Show("Record Inserted Successfully");

                txteno.Text = "";
                txtename.Text = "";
                txtsal.Text = "";
                txtdno.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string uploadUrl = "http://mahesh-pc/RESTVDDML/Service.svc/DeleteEmployee/" + txteno.Text;
            WebRequest addRequest = WebRequest.Create(uploadUrl);
            addRequest.Method = "POST";
            addRequest.ContentLength = 0;
            WebResponse addResponse = addRequest.GetResponse();

            MessageBox.Show("Record Deleted Successfully");
            txteno.Text = "";
        }

       

    }
}