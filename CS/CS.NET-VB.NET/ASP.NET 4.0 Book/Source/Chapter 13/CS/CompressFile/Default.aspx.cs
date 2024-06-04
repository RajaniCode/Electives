using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.IO.Compression;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Btncompress_Click(object sender, EventArgs e)
    {
        string path = Txtsrc.Text;
        FileStream sourceFile;
        FileStream destinationfile;
        GZipStream zip = null;
        try
        {
            sourceFile = File.OpenRead(path);
            destinationfile = File.Create(Txtdestination.Text + ".gzip");
            byte[] buffer = new byte[sourceFile.Length];
            sourceFile.Read(buffer, 0, buffer.Length);
            zip = new GZipStream(destinationfile, CompressionMode.Compress);
            zip.Write(buffer, 0, buffer.Length);
            zip.Close();
            sourceFile.Close();
            destinationfile.Close();
            lbldisplay.Text = "File is compressed and located at " + Txtdestination.Text;
        }
        catch (Exception ex)
        {
            lbldisplay.Text = ex.Message;
        }

    }
}