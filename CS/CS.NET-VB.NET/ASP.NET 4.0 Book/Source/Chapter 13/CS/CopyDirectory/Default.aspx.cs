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


    protected void BtnCopy_Click(object sender, EventArgs e)
    {
        try
        {
            DirectoryInfo SDir = new DirectoryInfo(TextBox1.Text);
            DirectoryInfo DDir = new DirectoryInfo(TextBox2.Text);
            CpyDir(SDir, DDir);
            Label2.Text = "Directory is copied ";
        }
        catch (Exception ex)
        {
            Label2.Text = ex.Message;
        }

    }
    static void CpyDir(DirectoryInfo src, DirectoryInfo destin)
    {
        if (!destin.Exists)
        {
            destin.Create();
            // To Copy all files
            FileInfo[] files = src.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destin.FullName, file.Name));
            }
            // Process subdirectories.
            DirectoryInfo[] dirs = src.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                string destinationDir = Path.Combine(destin.FullName, dir.Name);
                CpyDir(dir, new DirectoryInfo(destinationDir));
            }
        }
    }

}