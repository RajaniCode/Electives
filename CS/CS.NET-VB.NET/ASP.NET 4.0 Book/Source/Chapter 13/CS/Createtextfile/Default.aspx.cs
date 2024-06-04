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
    protected void BtnCreate_Click(object sender, EventArgs e)
    {
        string path;
        StreamWriter sw;      
        try
		{        
			path = TextBox1.Text;
			if (!File.Exists(path))
			{
				sw = File.CreateText(path);
                sw.WriteLine(TextBox2.Text);
			    sw.Close();
                Label2.Text = "File Created";
			}
			else
			{
                		Label1.Text = " The File already Exists at this location..Please change the file name"; 
			}
			
		}
		catch (Exception ex)
		{
			TextBox2.Text = ex.Message;
		}


    }
}