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
    public partial class Form2 : Form
    {
        Form1 F1; 

        /*
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 F1) : this()
        {
            this.F1 = F1;
        }   
        */

        public Form2(Form1 F1) // : base()
        {
            InitializeComponent();
            this.F1 = F1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F1.TextBoxText = textBox1.Text;
            this.Close();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            textBox1.Text = F1.TextBoxText;
            textBox1.Focus();
        }
    }
}
