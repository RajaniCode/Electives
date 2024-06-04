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
        // Declare our variables
        String[] sItems = new String[10];
        Int32[] iValue = new Int32[10];

        // Populate our variables
        sItems[0] = "Carrots";
        iValue[0] = 23;

        sItems[1] = "Peas";
        iValue[1] = 53;

        sItems[2] = "Celery";
        iValue[2] = 11;

        sItems[3] = "Onions";
        iValue[3] = 21;

        sItems[4] = "Radishes";
        iValue[4] = 43;




        // Set our axis values
        dngchart.YAxisValues = iValue;

       
        // Set our axis strings
        dngchart.YAxisItems = sItems;

        // Provide a title
        dngchart.ChartTitle = "<b>Inventory Breakdown:</b>";

        // Provide an title for the X-Axis
        // dngchart.XAxisTitle  = "(units display actual numbers)";        
    }
}

