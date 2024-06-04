using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Text;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(Server.MapPath("~/App_Data/Employees.xml"));
        
        
        Response.Write(xmldoc.SelectSingleNode("/Employees/Employee/FirstName").InnerText);
        Response.Write("<BR>");
        Response.Write(xmldoc.SelectSingleNode("/Employees/Employee[3]/FirstName").InnerText);
        Response.Write("<BR>");
        Response.Write(xmldoc.SelectSingleNode("/Employees/Employee[ID=101]/FirstName").InnerText);
        Response.Write("<BR>");
        Response.Write(xmldoc.SelectSingleNode("/Employees/Employee[ID=101]/@type").InnerText);
        Response.Write("<BR>");
        Response.Write(xmldoc.SelectNodes("/Employees/Employee[@type='Permanent']").Count.ToString());
        Response.Write("<BR>");
        Response.Write(xmldoc.SelectNodes("//Employee").Count.ToString());


        XmlNodeList nodes = xmldoc.SelectNodes("/Employees/Employee[@type='Permanent']");
        foreach (XmlNode node in nodes)
        {           
            ddlPermananentEmp.Items.Add(new ListItem(node.SelectSingleNode("FirstName").InnerText, node.SelectSingleNode("ID").InnerText));
        }

        nodes = xmldoc.SelectNodes("/Employees/Employee[@type='Contract']");
        foreach (XmlNode node in nodes)
        {
            ddlContractEmp.Items.Add(new ListItem(node.SelectSingleNode("FirstName").InnerText, node.SelectSingleNode("ID").InnerText));
        }


        nodes = xmldoc.SelectNodes("//Employee");
        foreach (XmlNode node in nodes)
        {
            ddlAllEmployees.Items.Add(new ListItem(node.SelectSingleNode("FirstName").InnerText, node.SelectSingleNode("ID").InnerText));
        }

        
    }
}

