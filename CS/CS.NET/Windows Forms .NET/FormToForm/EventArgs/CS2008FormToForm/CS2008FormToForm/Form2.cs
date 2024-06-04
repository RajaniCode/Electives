using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public partial class Form2 : Form
{
    public Form2()
    {
        InitializeComponent();
    }

    internal event CustomEventHandler Form2TextBoxEvent;

    internal void Form1_Form1TextBoxEvent(object sender, CustomEventArgs e)
    {
        textBox1.Text = e.TextBoxTextChanged;
    }

    private void OnForm2TextBoxEvent(CustomEventArgs e)
    {
        if(Form2TextBoxEvent != null)
            Form2TextBoxEvent(this, e);
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        CustomEventArgs Form2TextBoxEventArgs = new CustomEventArgs(textBox1.Text);
        OnForm2TextBoxEvent(Form2TextBoxEventArgs);
    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (((int)e.KeyChar) == 13)
            this.Close();
    }
}

