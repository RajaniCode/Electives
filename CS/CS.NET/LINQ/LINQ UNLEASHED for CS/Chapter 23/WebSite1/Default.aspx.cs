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
using System.Xml.XPath;


public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        XDocument doc = XmlData.GetData();
        XmlDataSource1.Data = doc.ToString();

        foreach (XElement elem in doc.Element("Customers").Elements("Customer").Elements())
        {
          TreeNodeBinding binding = new TreeNodeBinding();
          binding.DataMember = elem.Name.ToString();
          binding.TextField = "#InnerText";
          TreeView1.DataBindings.Add(binding);
        }

        TreeView1.DataSource = XmlDataSource1;
        TreeView1.DataBind();
      }
    }
}
