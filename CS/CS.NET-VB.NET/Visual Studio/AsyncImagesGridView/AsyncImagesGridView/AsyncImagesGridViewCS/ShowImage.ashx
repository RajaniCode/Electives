<%@ WebHandler Language="C#" Class="ShowImage" %>
 
using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
 
public class ShowImage : IHttpHandler
{
    long seq = 0;
    byte[] empPic = null;

    public void ProcessRequest(HttpContext context)
    {
        Int32 picid;
        if (context.Request.QueryString["id"] != null)
            picid = Convert.ToInt32(context.Request.QueryString["id"]);
        else
            throw new ArgumentException("No parameter specified");

        // Convert Byte[] to Bitmap
        Bitmap newBmp = ConvertToBitmap(ShowAlbumImage(picid));
        if (newBmp != null)
        {
            newBmp.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            newBmp.Dispose();
        }

    }

    // Convert byte array to Bitmap (byte[] to Bitmap)
    protected Bitmap ConvertToBitmap(byte[] bmp)
    {
        if (bmp != null)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            Bitmap b = (Bitmap)tc.ConvertFrom(bmp);
            return b;
        }
        return null;
    }
 
    public byte[] ShowAlbumImage(int picid)
    {
        string conn = ConfigurationManager.ConnectionStrings["PictureAlbumConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        string sql = "SELECT pic FROM Album WHERE Pic_ID = @ID";
        SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID", picid);
        try
        {
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                seq = dr.GetBytes(0, 0, null, 0, int.MaxValue) - 1;
                empPic = new byte[seq + 1];
                dr.GetBytes(0, 0, empPic, 0, Convert.ToInt32(seq));
                connection.Close();
            }

            return empPic;
        }

        catch
        {
            return null;
        }
        finally
        {
            connection.Close();
        }
    }
 
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
 
 
}
