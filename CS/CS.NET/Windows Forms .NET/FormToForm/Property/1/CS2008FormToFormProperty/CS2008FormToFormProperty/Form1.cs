using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS2008FormToFormProperty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        internal string TextBoxText
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }    

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();

            F2.ShowInTaskbar = false;
            F2.ShowDialog();
        }

        //Bug
        private void button2_Click(object sender, EventArgs e)
        {
            //this.ShowInTaskbar = !this.ShowInTaskbar;
            MessageBox.Show("Number of open forms: " + Application.OpenForms.Count);       
        }
    }
}
