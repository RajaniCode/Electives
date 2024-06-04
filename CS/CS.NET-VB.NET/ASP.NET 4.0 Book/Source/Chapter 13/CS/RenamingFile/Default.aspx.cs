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
    protected void BtnRename_Click(object sender, EventArgs e)
    {
        string strsorc = TextBox1.Text;
        string strdest = TextBox2.Text;
        try
        {
            FileInfo sourcefile = new FileInfo(strsorc);
            if (sourcefile.Exists)
            {
                sourcefile.MoveTo(strdest);
                Label3.Text = " File is renamed";
            }
            else
            {
                Label3.Text = "file not found";
            }
        }
        catch (Exception ex)
        {
            Label3.Text = ex.Message;
        }

    }
}