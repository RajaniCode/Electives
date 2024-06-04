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
    protected void Button1_Click(object sender, EventArgs e)
    {
      localhost.WebService ws = new localhost.WebService();

        Double SI=0;
        if ((txtPrincipal.Text == "") || (txtRate.Text == "") || (txtDuration.Text == ""))
        {
            Label5.Text = "Unable to calculate simple interest";
        }
        else
        {
           SI = ws.CalculateSimpleInterest(System.Convert.ToDouble(txtPrincipal.Text),System.Convert.ToDouble(txtRate.Text), System.Convert.ToInt32(txtDuration.Text));
            txtSimpleInterest.Enabled = true;
            txtSimpleInterest.Text = SI.ToString();
            Label5.Text = "";
        }
    }
}