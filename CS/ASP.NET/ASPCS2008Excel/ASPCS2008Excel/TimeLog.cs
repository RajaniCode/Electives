using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.IO;

namespace ASPCS2008Excel
{
    public static class TimeLog
    {
        public static void WriteTimeLog(string strComment)
        {
            StreamWriter sw;
            string strFilePath = ConfigurationSettings.AppSettings["LogFilePath"].ToString();

            if (!Directory.Exists(Path.GetDirectoryName(strFilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strFilePath));
            }

            if (File.Exists(strFilePath))
            {
                sw = File.AppendText(strFilePath);
            }
            else
            {
                sw = File.CreateText(strFilePath);
            }

            sw.WriteLine(strComment + ":\t" + DateTime.Now.ToString("yyyyMMdd-HH:mm:ss.fff"));
            sw.Close();
        }
    }
}
