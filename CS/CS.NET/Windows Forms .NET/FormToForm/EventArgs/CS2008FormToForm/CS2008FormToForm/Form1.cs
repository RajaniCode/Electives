using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private Form2 F2;

    private event CustomEventHandler Form1TextBoxEvent;

    private void Form2_Form2TextBoxText(object sender, CustomEventArgs e)
    {
        textBox1.Text  = e.TextBoxTextChanged;
    }

    private void OnForm1TextBoxEvent(CustomEventArgs e)
    {
        if(Form1TextBoxEvent != null)
            Form1TextBoxEvent(this, e);
    }
        
    private void button1_Click(object sender, EventArgs e)
    {
        F2 = new Form2();

        // Form1TextBoxEvent += new CustomEventHandler(F2.Form1_Form1TextBoxEvent);
        Form1TextBoxEvent += F2.Form1_Form1TextBoxEvent;

        CustomEventArgs Form1TextBoxEventArgs = new CustomEventArgs(textBox1.Text);
        OnForm1TextBoxEvent(Form1TextBoxEventArgs);

        // F2.Form2TextBoxEvent += new CustomEventHandler(Form2_Form2TextBoxText);
        F2.Form2TextBoxEvent += Form2_Form2TextBoxText;

        F2.ShowInTaskbar = false;
        F2.ShowDialog();
    }
}

