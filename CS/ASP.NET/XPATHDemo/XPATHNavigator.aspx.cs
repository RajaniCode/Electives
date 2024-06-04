using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

public partial class XPATHNavigator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        XPathDocument xpathdoc = new XPathDocument(Server.MapPath("~/App_Data/Employees.xml"));
        XPathNavigator navigator = xpathdoc.CreateNavigator();
        XPathExpression expr = navigator.Compile("/Employees/Employee[@type='Permanent']");
        XPathNodeIterator nodes = navigator.Select(expr);

        while (nodes.MoveNext())
        {
            ddlEmployees.Items.Add(new ListItem(nodes.Current.SelectSingleNode("FirstName").Value, nodes.Current.SelectSingleNode("ID").Value));
        }


    }
}
