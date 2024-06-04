using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Btnfile_Click(object sender, EventArgs e)
    {
        FileStream fs;
        try
        {
            fs = File.Open(TextBox1.Text, FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            if (File.Exists(TextBox1.Text))
            {
                Label1.Text = "File is opened";
                sw.WriteLine(TextBox2.Text);
                sw.Close();
                Lbldisplay.Text = "File is saved at" + TextBox1.Text + "  and data is replaced with the new data"; 
            }
        }
        catch (Exception ex)
        {
            Lbldisplay.Text = ex.Message;
        }

    }
  
}