using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) Label3.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {

            FileUpload1.SaveAs("D:/" + FileUpload1.FileName);
            Label3.Text = "File " + FileUpload1.FileName + " is Uploaded";
        }
        else
            Label3.Text = "No uploaded file";
    }

}