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
        string directorypath = TextBox1.Text;
		System.IO.DirectoryInfo subdir = new DirectoryInfo(TextBox1.Text);
		try
		{
			string subname = TextBox2.Text;
			{
				subdir.CreateSubdirectory(subname);
				Label2.Text = "Subdirectory: " + subname + "  is created at "+directorypath; 
			}
		}
		catch(Exception ex) 
		{
			Label2.Text = ex.Message;
		}

    }
}