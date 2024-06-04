using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS2008ToAndFroForms
{
    public partial class Form2 : Form
    {
        internal event CustomEventHandler Form2TextBoxEvent;

        public Form2()
        {
            InitializeComponent();
        }

        internal void Form1_Form1TextBoxEvent(object sender, CustomEventArgs e)
        {
            textBox1.Text = e.TextBoxTextChanged;
        }

        private void OnForm2TextBoxEvent(CustomEventArgs e)
        {
            if (Form2TextBoxEvent != null)
                Form2TextBoxEvent(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomEventArgs Form2TextBoxEventArgs = new CustomEventArgs(textBox1.Text);
            OnForm2TextBoxEvent(Form2TextBoxEventArgs);

            this.Close();
        }
    }
}
