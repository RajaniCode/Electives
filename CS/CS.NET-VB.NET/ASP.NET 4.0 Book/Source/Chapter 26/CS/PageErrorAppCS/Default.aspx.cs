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
    void Page_Error(object sender, EventArgs e)
    {
        Response.Write("Error occured: <br />" + Server.GetLastError().ToString());
        Server.ClearError();
    }
    void PageLevelErrorTest()
    {
        int[] array = new int[9];
        for (int intCounter = 0; intCounter <= 9; intCounter++)
        {
            array[intCounter] = intCounter;
            Response.Write("The value of counter is: " + intCounter + "<br />");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        PageLevelErrorTest();
    }
}