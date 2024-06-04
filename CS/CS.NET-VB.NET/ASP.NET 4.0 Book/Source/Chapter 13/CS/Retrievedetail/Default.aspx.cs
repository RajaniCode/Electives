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
    protected void Btnshow_Click(object sender, EventArgs e)
    {
        string str;
    
        try
        {
            str = TextBox1.Text;
            TextBox2.Text = " File Attributes :  " + File.GetAttributes(str) + "  Created at: " + File.GetCreationTime(str).ToString() +" Last Accessed at :" + File.GetLastAccessTime(str);
        }
        catch (Exception ex)
        {
            TextBox2.Text = ex.Message;
        }

    }
}