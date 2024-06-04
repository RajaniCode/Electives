<%@ WebHandler Language="C#" Class="ShowImage" %>
 
using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
 
public class ShowImage : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        Int32 picid;
        if (context.Request.QueryString["id"] != null)
            picid = Convert.ToInt32(context.Request.QueryString["id"]);
        else
            throw new ArgumentException("No parameter specified");
 
        context.Response.ContentType = "image/jpeg";
        Stream strm = ShowAlbumImage(picid);
        byte[] buffer = new byte[4096];
        int byteSeq = strm.Read(buffer, 0, 4096);
 
        while (byteSeq > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, byteSeq);
            byteSeq = strm.Read(buffer, 0, 4096);
        }
        //context.Response.BinaryWrite(buffer);
    }
 
    public Stream ShowAlbumImage(int picid)
    {
        string conn = ConfigurationManager.ConnectionStrings["albumConnString"].ConnectionString;
        SqlConnection connection = new SqlConnection(conn);
        string sql = "SELECT pic FROM Album WHERE Pic_ID = @ID";
        SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ID", picid);
        connection.Open();
        object img = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])img);
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