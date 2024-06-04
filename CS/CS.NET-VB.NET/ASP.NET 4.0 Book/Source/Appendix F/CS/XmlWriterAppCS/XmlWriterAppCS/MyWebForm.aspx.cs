using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace XmlWriterAppCS
{
    public partial class MyWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlWriterSettings docSettings = new XmlWriterSettings();
            docSettings.Indent = true;
            docSettings.Encoding = Encoding.UTF8;

            string docPath = Server.MapPath("Employees.xml");
            try
            {
                using (XmlWriter xr = XmlWriter.Create(docPath, docSettings))
                {
                    xr.WriteStartDocument();
                    xr.WriteComment("This File Displays Employee Details");
                    xr.WriteStartElement("Employees");
                    xr.WriteStartElement("Employee");
                    xr.WriteAttributeString("ID", "Emp1");
                    xr.WriteStartElement("Name");
                    xr.WriteElementString("FirstName", "Gerry");
                    xr.WriteElementString("LastName", "Simpson");
                    xr.WriteEndElement();
                    xr.WriteElementString("Age", "25");
                    xr.WriteElementString("Designation", "Manager");
                    xr.WriteStartElement("Location");
                    xr.WriteElementString("City", "New Delhi");
                    xr.WriteElementString("Country", "India");
                    xr.WriteEndElement();
                    xr.WriteEndElement();
                    xr.WriteEndElement();
                    xr.WriteEndDocument();
                }
                Response.Redirect("Employees.xml");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}