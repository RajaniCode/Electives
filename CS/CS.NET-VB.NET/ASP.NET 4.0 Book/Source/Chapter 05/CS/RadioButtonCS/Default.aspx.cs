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
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton1.Text;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton4.Checked = false;
        RadioButton5.Checked = false;

    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton2.Text;
        RadioButton1.Checked = false;
        RadioButton3.Checked = false;
        RadioButton4.Checked = false;
        RadioButton5.Checked = false;

    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton3.Text;
        RadioButton2.Checked = false;
        RadioButton1.Checked = false;
        RadioButton4.Checked = false;
        RadioButton5.Checked = false;

    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton4.Text;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton1.Checked = false;
        RadioButton5.Checked = false;

    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
        Label3.Text = "<font color=black>You have selected: </font>" + RadioButton5.Text;
        RadioButton2.Checked = false;
        RadioButton3.Checked = false;
        RadioButton1.Checked = false;
        RadioButton4.Checked = false;

    }
}