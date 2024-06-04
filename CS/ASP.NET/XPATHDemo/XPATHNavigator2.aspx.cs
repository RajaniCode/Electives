using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

public partial class XPATHNavigator2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XPathDocument xpathdoc = new XPathDocument(Server.MapPath("~/App_Data/Employees.xml"));
        XPathNavigator navigator = xpathdoc.CreateNavigator();       
        XPathNodeIterator nodes = navigator.Select("/Employees/Employee[@type='Permanent']/FirstName");

        while (nodes.MoveNext())
        {
            Response.Write(nodes.Current.Value);
            Response.Write("<BR>");
        }
    }
}
