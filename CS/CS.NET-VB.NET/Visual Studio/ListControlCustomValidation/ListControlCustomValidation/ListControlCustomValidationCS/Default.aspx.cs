using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page 
{
protected void Page_Load(object sender, EventArgs e)
{
    if (!Page.IsPostBack)
    {
        List<string> lstStr = new List<string>();
        lstStr.Add("Item 1");
        lstStr.Add("Item 2");
        lstStr.Add("Item 3");
        lstStr.Add("Item 4");
        CheckBoxList1.DataSource = lstStr;
        CheckBoxList1.DataBind();
        RadioButtonList1.DataSource = lstStr;
        RadioButtonList1.DataBind();            
    }
}

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
