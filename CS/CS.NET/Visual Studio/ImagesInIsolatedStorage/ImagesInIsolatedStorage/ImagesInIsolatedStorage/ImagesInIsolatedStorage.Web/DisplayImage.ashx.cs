using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Services;
using System.ComponentModel;

namespace ImagesInIsolatedStorage.Web
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DisplayImage : IHttpHandler
    {
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
}
