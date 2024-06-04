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
    protected void BtnShow_Click(object sender, EventArgs e)
    {
        string[] str = Directory.GetLogicalDrives();
        for (int i = 0; i < str.Length; i++)
        {
            DropDownList1.Items.Add(str[i]);
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
         try
		{
			string driv = DropDownList1.SelectedValue;
			Label1.Text = "You Have Selected Drive " + driv;
			System.IO.DriveInfo retrieve_drive_info = new System.IO.DriveInfo(driv);
			Label2.Text = "Drive Type : " + retrieve_drive_info.DriveType.ToString();
			Label4.Text = "Free Space on Drive: " + 
 			  retrieve_drive_info.AvailableFreeSpace.ToString();
			Label3.Text = "Total Size : " + retrieve_drive_info.TotalSize.ToString();
		}
		catch (Exception ex)
		{
			Label2.Text=ex.Message;
            Label4.Text = " ";
            Label3.Text = " ";
		}
	}
    }
