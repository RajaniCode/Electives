using System;
using System.IO;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            string fileContent = Cache["SampleFile"] as string;
            if (string.IsNullOrEmpty(fileContent))
            {
                using (StreamReader sr = File.OpenText(Server.MapPath("~/SampleFile.txt")))
                {
                    fileContent = sr.ReadToEnd();
                    Cache.Insert("SampleFile", fileContent, new System.Web.Caching.CacheDependency(Server.MapPath("~/SampleFile.txt")));
                }
            }    
            TextBox1.Text = fileContent;
        }
    }
}
