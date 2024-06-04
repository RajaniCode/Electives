using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection connection = null;
        try
        {
            FileUpload img = (FileUpload)imgUpload;
            Byte[] imgByte = null;
            if (img.HasFile && img.PostedFile != null)
            {
                //To create a PostedFile
                HttpPostedFile File = imgUpload.PostedFile;
                //Create byte Array with file len
                imgByte = new Byte[File.ContentLength];
                //force the control to load data in array
                File.InputStream.Read(imgByte, 0, File.ContentLength);
            }
            // Insert the picture tag and image into db
            string conn = ConfigurationManager.ConnectionStrings["albumConnString"].ConnectionString;
            connection = new SqlConnection(conn);

            connection.Open();
            string sql = "INSERT INTO Album(picture_tag,pic) VALUES(@tag,@pic) SELECT @@IDENTITY";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@tag", txtTags.Text);
            cmd.Parameters.AddWithValue("@pic", imgByte);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            lblResult.Text = String.Format("Picture ID is {0}", id);
            ListView1.DataBind();
        }
        catch
        {
            lblResult.Text = "There was an error";
        }
        finally
        {
            connection.Close();
        }
    }
}
