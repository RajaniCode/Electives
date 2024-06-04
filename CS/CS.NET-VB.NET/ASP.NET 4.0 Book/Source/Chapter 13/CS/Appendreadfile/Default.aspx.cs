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

    protected void BtnRead_Click(object sender, EventArgs e)
    {
        try
        {
            String filename = Server.MapPath(TextBox1.Text);
            StreamReader reader;
            reader = File.OpenText(filename);
            String str = reader.ReadToEnd();
            TextBox2.Text = str;
            reader.Close();
            Label2.Text = "File Found and Read successfully!";
        }
        catch (Exception ex)
        {
            Label2.Text = ex.Message;
        }
    }
    protected void Btnappend_Click(object sender, EventArgs e)
    {
        try
        {
            String filename = Server.MapPath(TextBox1.Text);
            StreamWriter sw = File.AppendText(filename);
            sw.WriteLine(TextBox2.Text);
            sw.Close();
            Label2.Text = "Text Appended successfully!";
        }
        catch (Exception ex)
        {
            Label2.Text = ex.Message;
        }

    }
}