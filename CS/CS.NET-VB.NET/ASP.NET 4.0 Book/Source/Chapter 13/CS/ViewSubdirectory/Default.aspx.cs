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
        string path = TextBox1.Text;
        DirectoryInfo maindir = new DirectoryInfo(path);
        if (maindir.Exists)
        {
            DirectoryInfo[] subdir = maindir.GetDirectories();
            for (int i = 0; i < subdir.Length; i++)
            {
                ListBox1.Items.Add("Name : " + subdir[i]);
            }
        }
        else
        {
            ListBox1.Items.Add("Main Directory Does not exists");
        }

    }
}