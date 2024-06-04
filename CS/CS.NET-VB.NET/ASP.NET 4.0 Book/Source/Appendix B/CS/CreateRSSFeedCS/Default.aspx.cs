using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Xml;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
		{

			Response.Clear();
			Response.ContentType = "text/xml";
			XmlTextWriter XMLTextObject = new XmlTextWriter(Response.OutputStream, 
			Encoding.UTF8);
			XMLTextObject.WriteStartDocument();
			XMLTextObject.WriteStartElement("rss");
			XMLTextObject.WriteAttributeString("version", "2.0");
			XMLTextObject.WriteStartElement("channel");
			XMLTextObject.WriteElementString("title", "Sample News Channel");
			XMLTextObject.WriteElementString("link", 
			"http://www.somedomain.com/news.aspx");
			XMLTextObject.WriteElementString("description", "This is a sample RSS 2.0 Feed");
			XMLTextObject.WriteElementString("copyright", "(c) 2006,  All rights reserved.");
			XMLTextObject.WriteElementString("ttl", "5");
			string connectionstring = "Data Source=.\\sqlexpress;Initial Catalog=rsssample;Integrated Security=True";
			SqlConnection objConnection = new SqlConnection(connectionstring);
			objConnection.Open();
			string sql = "SELECT TOP 3 newstitle, newsdescription, newsdate FROM newsdata ORDER BY newsdate DESC";
			SqlCommand objCommand = new SqlCommand(sql, objConnection);
			SqlDataReader objReader = objCommand.ExecuteReader();
			while (objReader.Read())
			{
				XMLTextObject.WriteStartElement("item");
				XMLTextObject.WriteElementString("title", 
				objReader.GetString(0));
				XMLTextObject.WriteElementString("description", 
				objReader.GetString(1));
				XMLTextObject.WriteElementString("link", 
				"http://www.somedomain.com/GetArticle.aspx?id=0");
				XMLTextObject.WriteElementString("pubDate", 
				objReader.GetDateTime(2).ToString("R"));
				XMLTextObject.WriteEndElement();
			}
			objReader.Close();
			objConnection.Close();

			XMLTextObject.WriteEndElement();
			XMLTextObject.WriteEndElement();
			XMLTextObject.WriteEndDocument();
			XMLTextObject.Flush();
			XMLTextObject.Close();
			Response.End();
		}
		catch (Exception ex)
		{
			Label1.Text = ex.Message;
		}
	}

    }
