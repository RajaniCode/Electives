<%@ WebHandler Language="C#" Class="TextOnImageHandler" %>

using System;
using System.Web;
using System.Drawing;
using System.Configuration;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;

public class TextOnImageHandler : IHttpHandler {

    byte[] empPic = null;
    long seq = 0;

    public void ProcessRequest(HttpContext context)
    {
        Int32 empno;

        if (context.Request.QueryString["id"] != null)
            empno = Convert.ToInt32(context.Request.QueryString["id"]);
        else
            throw new ArgumentException("No parameter specified");

        // Convert Byte[] to Bitmap
        Bitmap newBmp = ConvertToBitmap(ShowEmpImage(empno));
        // Watermark Text to be added to image
        string text = "Code from dotnetcurry";
        Bitmap convBmp = AddTextToImage(newBmp, text);
        convBmp.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        newBmp.Dispose();
        convBmp.Dispose();
    }

    // Add Watermark Text to Image
    protected Bitmap AddTextToImage(Bitmap bImg, string msg)
    {
        // To void the error due to Indexed Pixel Format
        Image img = new Bitmap(bImg, new Size(bImg.Width, bImg.Height));
        Bitmap tmp = new Bitmap(img);
        Graphics graphic = Graphics.FromImage(tmp);
        // Watermark effect
        SolidBrush brush = new SolidBrush(Color.FromArgb(120, 255, 255, 255));
        // Draw the text string to the Graphics object at a given position.
        graphic.DrawString(msg, new Font("Times New Roman", 14, FontStyle.Italic),
             brush, new PointF(10, 30));
        graphic.Dispose();
        return tmp;
    }

    // Convert byte array to Bitmap (byte[] to Bitmap)
    protected Bitmap ConvertToBitmap(byte[] bmp)
    {
        TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
        Bitmap b = (Bitmap)tc.ConvertFrom(bmp);
        return b;
    }

    public byte[] ShowEmpImage(int empno)
    {
        string conn = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        string sql = "SELECT photo FROM Employees WHERE EmployeeID = @ID";
        SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID", empno);
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

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}