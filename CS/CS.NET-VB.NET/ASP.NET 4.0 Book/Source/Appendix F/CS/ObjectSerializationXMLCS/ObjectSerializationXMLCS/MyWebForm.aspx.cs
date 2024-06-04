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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;

namespace ObjectSerializationXMLCS
{
    public partial class MyWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [XmlRoot("employee")]
        public class Employee
        {
            private int empID;
            private string empName;
            private Decimal empSalary;
            [XmlElement("id")]
            public int ID
            {
                get
                {
                    return empID;
                }
                set
                {
                    empID = value;
                }
            }
            [XmlElement("name")]
            public string Name
            {
                get
                {
                    return empName;
                }
                set
                {
                    empName = value;
                }
            }
            [XmlElement("salary")]
            public decimal Salary
            {
                get
                {
                    return empSalary;
                }
                set
                {
                    empSalary = value;
                }
            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            String XMLPath = "D:\\employee.xml";
            XmlDocument empdoc = new XmlDocument();
            Response.ContentType = "text/xml";
            try
            {
                empdoc.Load(XMLPath);
                Response.Write(empdoc.InnerXml);
                Response.End();
            }
            catch (XmlException ex)
            {
                Response.Write("XMLException:" + ex.Message);
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.ID = 101;
            emp.Name = "Steve";
            emp.Salary = 6000;
            TextWriter tw = new StreamWriter("D:\\employee.xml");
            XmlSerializer xs = new XmlSerializer(typeof(Employee));
            xs.Serialize(tw, emp);
            tw.Close();
            FileStream fs = new FileStream("D:\\employee.xml", FileMode.Open);
            XmlSerializer newXs = new XmlSerializer(typeof(Employee));
            Employee emp1 = (Employee)newXs.Deserialize(fs);
            if (emp1 != null)
            {
                ListBox1.Items.Add(emp1.ID.ToString());
                ListBox1.Items.Add(emp1.Name.ToString());
                ListBox1.Items.Add(emp1.Salary.ToString());
            }
            fs.Close();
        }
    }
}