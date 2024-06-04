using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Principal;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "Welcome, " + HttpContext.Current.User.Identity.Name;        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Text = "Impersonated account: " + WindowsIdentity.GetCurrent().Name;
        DirectoryInfo directory = new DirectoryInfo(@"D:\MyFolder");
        FileInfo[] files = directory.GetFiles("*.*");
        foreach (FileInfo f in files)
        {
            ListBox1.Items.Add(f.FullName);
        }                     

    }
}