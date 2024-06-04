using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class BarChart : System.Web.UI.UserControl
{
    private String _sXAxisTitle;
    private String _sChartTitle;
    private Int32 _iUserWidth = 300;
    private String[] _sYAxisItems;
    private Int32[] _iYAxisValues;

    public Int32 UserWidth
    {
        get { return _iUserWidth; }
        set { _iUserWidth = value; }
    }

    public Int32[] YAxisValues
    {
        get { return _iYAxisValues; }
        set { _iYAxisValues = value; }
    }

    public String[] YAxisItems
    {
        get { return _sYAxisItems; }
        set { _sYAxisItems = value; }
    }

    public String XAxisTitle
    {
        get { return _sXAxisTitle; }
        set { _sXAxisTitle = value; }
    }

    public String ChartTitle
    {
        get { return _sChartTitle; }
        set { _sChartTitle = value; }
    }

    void Page_Load(Object sender, EventArgs e)
    {

        // As long as we have values to display, do so
        if (_iYAxisValues != null)
        {

            // Color array
            String[] sColor = new String[9];
            sColor[0] = "red";
            sColor[1] = "lightblue";
            sColor[2] = "green";
            sColor[3] = "orange";
            sColor[4] = "yellow";
            sColor[5] = "blue";
            sColor[6] = "lightgrey";
            sColor[7] = "pink";
            sColor[8] = "purple";

            // Initialize the color category
            Int32 iColor = 0;

            // Display the chart title
            lblChartTitle.Text = _sChartTitle;

            // Get the largest value from the available items
            Int32 iMaxVal = 0;
            for (int i = 0; i < _iYAxisValues.Length; i++)
            {
                if (_iYAxisValues[i] > iMaxVal)
                    iMaxVal = _iYAxisValues[i];
            }

            // Take the user-provided maximum width of the chart, and divide it by the
            // largest value in our valueset to obtain the modifier
            Int32 iMod = Math.Abs(_iUserWidth / iMaxVal);

            // This will be the string holder for our actual bars.
            String sOut = "";

            // Render a bar for each item
            for (int i = 0; i < _iYAxisValues.Length; i++)
            {

                // Only display this item if we have a value to display
                if (_iYAxisValues[i] > 0)
                {

                    sOut += "<tr><td align=right>" + _sYAxisItems[i] + "</td>";
                    sOut += "<td>" + RenderItem(_iYAxisValues[i], iMod, sColor[iColor]) + "</td></tr>";
                    iColor++;

                    // If we have reached the end of our color array, start over
                    if (iColor > 8) iColor = 0;
                }
            }

            // Place the rendered string in the appropriate label
            lblItems.Text = sOut;

            // Drop in the Y Axis label
            lblXAxisTitle.Text = _sXAxisTitle;
        }
    }

    private String RenderItem(Int32 iVal, Int32 iMod, String sColor)
    {
        String sRet = "";
        sRet += "<table border=0 bgcolor=" + sColor + " cellpadding=0 cellspacing=0><tr>";
        sRet += "<td align=center width=" + (iVal * iMod) + " nobr nowrap>";
        sRet += "<b>" + iVal + "</b>";
        sRet += "</tr><td></table>";
        return sRet;
    }
}
