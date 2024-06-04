using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Xml;

namespace WorkingWithStreamedXMLCS
{
    public partial class MyWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
	{
		ListBox1.Items.Clear();
		XmlReader xr = XmlReader.Create("D:\\Books\\Black Book\\ASP.NET 4.0_BB\\Source Code\\Appendix F\\CS\\WorkingWithStreamedXMLCS\\WorkingWithStreamedXMLCS\\Authors.xml");
		while (xr.Read())
		{
			if (xr.NodeType == XmlNodeType.Text)
			ListBox1.Items.Add(xr.Value);
		}
	}
	protected void Button2_Click(object sender, EventArgs e)
	{
		ListBox1.Items.Clear();
		XmlReader xr = XmlReader.Create("D:\\Books\\Black Book\\ASP.NET 4.0_BB\\Source Code\\Appendix F\\CS\\WorkingWithStreamedXMLCS\\WorkingWithStreamedXMLCS\\Authors.xml");
		while (xr.Read())
		{
			if (xr.NodeType == XmlNodeType.Element && xr.Name == "au_lname")
			ListBox1.Items.Add(xr.ReadElementString());
			else
			xr.Read();
		}
	}
	protected void Button3_Click(object sender, EventArgs e)
	{
		ListBox1.Items.Clear();
		XmlReader xr = XmlReader.Create("D:\\Books\\Black Book\\ASP.NET 4.0_BB\\Source Code\\Appendix F\\CS\\WorkingWithStreamedXMLCS\\WorkingWithStreamedXMLCS\\Authors.xml");
		while (xr.Read())
		{
			if (xr.NodeType == XmlNodeType.Element)
			{
				for (int i = 0; i < xr.AttributeCount; i++)
				ListBox1.Items.Add(xr.GetAttribute(i));
			}
		}
	}
    }
}