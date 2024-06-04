using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }   

    protected void CheckBox1_CheckedChanged1(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            ListBox1.Items.Add(CheckBox1.Text);
        }
        else
        {
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox1.Text));
        }
    }
    protected void CheckBox2_CheckedChanged1(object sender, EventArgs e)
    {
        if (CheckBox2.Checked == true)
        {
            ListBox1.Items.Add(CheckBox2.Text);
        }
        else
        {
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox2.Text));
        }
    }
    protected void CheckBox3_CheckedChanged1(object sender, EventArgs e)
    {
        if (CheckBox3.Checked == true)
        {
            ListBox1.Items.Add(CheckBox3.Text);
        }
        else
        {
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox3.Text));
        }
    }
    protected void CheckBox4_CheckedChanged1(object sender, EventArgs e)
    {
        if (CheckBox4.Checked == true)
        {
            ListBox1.Items.Add(CheckBox4.Text);
        }
        else
        {
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox4.Text));
        }
    }
    protected void CheckBox5_CheckedChanged1(object sender, EventArgs e)
    {
        if (CheckBox5.Checked == true)
        {
            ListBox1.Items.Add(CheckBox5.Text);
        }
        else
        {
            ListBox1.Items.Remove(ListBox1.Items.FindByText(CheckBox5.Text));
        }
    }
}