using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Ports;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        

    }
    protected void BtnSend_Click(object sender, EventArgs e)
    {
        try
        {
            SerialPort senddata = new SerialPort();
            senddata.PortName = "COM1";
            senddata.Open();
            senddata.Write(TextBox1.Text + "!%");
            senddata.Close();
            Label2.Text = "Data is sent to the serial port";
        }
        catch (Exception ex)
        {
            Label2.Text = ex.Message;
        }

    }
}