using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Globalization;

/// <summary>
/// Summary description for ErrHandler
/// </summary>
public class ErrHandler
{
	public ErrHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// Handles error by accepting the error message 
    /// Displays the page on which the error occured
    public static void WriteError(string errorMessage)
    {
        try
        {
            string path = "~/Error/" + DateTime.Today.ToString("dd-mm-yy") + ".txt";
            if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() +
                              ". Error Message:" + errorMessage;
                w.WriteLine(err);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }
        }
        catch (Exception ex)
        {
            WriteError(ex.Message);
        }

    }
}
