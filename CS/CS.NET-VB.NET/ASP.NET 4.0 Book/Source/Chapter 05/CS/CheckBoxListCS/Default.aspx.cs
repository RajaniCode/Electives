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
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s;

        s = "<font color=black> Selected Employees:</font><br>";
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                s = s + CheckBoxList1.Items[i].Text + "<br>";
            }

        }
        Label3.Text = s;
    }
}