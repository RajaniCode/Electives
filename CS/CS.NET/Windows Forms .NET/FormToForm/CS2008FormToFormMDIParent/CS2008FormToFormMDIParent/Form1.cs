using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS2008FormToFormMDIParent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Note:  Application.Run(new MDIParent1());

        internal delegate void MyEventHandler(Object sender, MyEventArgs e);
        internal event MyEventHandler ButtonClicked;

        private void OnButtonClicked(MyEventArgs myEventArgs)
        {
            if (this.ButtonClicked != null)
            {
                this.ButtonClicked.Invoke(this, myEventArgs);
            }
            return;
        }

        internal void UpdateUI_TextBox1(MyEventArgs e)
        {
            string userState = e.UserState as String;
            if (userState != null)
            {
                this.textBox1.Text = userState;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OnButtonClicked(new MyEventArgs(this.textBox1.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = String.Empty;
            this.button1.Click += new EventHandler(button1_Click);
        }
    }
}
