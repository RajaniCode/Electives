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
        
		string path = TextBox1.Text;
		Label2.Text = "";
		try
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
				Label2.Text = "Directory is Created...."+path;
			}
			else
			{
				if (Directory.Exists(path))
				{
					Label2.Text = " Directory Is already Created at " + path;
				}
			}
		}
		catch (Exception ex)
		{
		Label2.Text = "Please Check The Path and Name of Directory, " + ex.Message;
		}
	}

    
}