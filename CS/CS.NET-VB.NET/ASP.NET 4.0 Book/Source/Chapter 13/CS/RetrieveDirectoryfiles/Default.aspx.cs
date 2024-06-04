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
        DirectoryInfo dir = new DirectoryInfo(path);
        if (dir.Exists)
        {
            FileInfo[] files = dir.GetFiles("*");
            foreach (FileInfo file in files)
            {
                ListBox1.Items.Add("Name " + file.Name + "  Size: " + file.Length.ToString());
            }
            Label2.Text="Directory Exists";
        }
        else
        {
            Label2.Text = "Directory at " + path + " Does not exists";
        }

    }
}