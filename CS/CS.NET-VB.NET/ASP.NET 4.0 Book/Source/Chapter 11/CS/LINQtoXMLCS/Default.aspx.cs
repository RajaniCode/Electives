using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            XElement employees = XElement.Parse
            (
                @"<employees>
				<employee>
				<ID>E001</ID>
				<name>Ram</name>
				<designation>Writer</designation>
				</employee>
				<employee>
				<ID>E002</ID>
				<name>Harry</name>
				<designation>Manager</designation>
				</employee>
				<employee>
				<ID>E003</ID>
				<name>Neha </name>
				<designation>Writer</designation>
				</employee>
				<employee>
				<ID>E004</ID>
				<name>Umar</name>
				<designation>Writer</designation>
				</employee>
				<employee>
				<ID>E005</ID>
				<name>Shivam</name>
				<designation>Writer</designation>
				</employee>
				<employee>
				<ID>E006</ID>
				<name>Frensesco</name>
				<designation>Manager</designation>
				</employee>
				<employee>
				<ID>E007</ID>
				<name>Peter</name>
				<designation>Manager</designation>
				</employee>
				<employee>
				<ID>E008</ID>
				<name>Puja</name>
				<designation>Writer</designation>
				</employee>
				<employee>
				<ID>E009</ID>
				<name>Dheeraj</name>
				<designation>Writer</designation>
				</employee>
				<employee>
				<ID>E0010</ID>
				<name>Jaison</name>
				<designation>Manager</designation>
				</employee>
				</employees>
			");
            ListBox1.Items.Add("The Employees who are Writers are:");
            var names = from employee in employees.Elements("employee")
                        where (string)employee.Element("designation") == "Writer"
                        select employee.Element("name");
            foreach (var title in names)
            {
                ListBox1.Items.Add(title.Value);
            }
            ListBox1.Items.Add("The Employees who are Managers are:");
            var names1 = from employee in employees.Elements("employee")
                         where (string)employee.Element("designation") == "Manager"
                         select employee.Element("name");
            foreach (var title in names1)
            {
                ListBox1.Items.Add(title.Value);
            }
        }
        catch (Exception ex)
        {
            ListBox1.Items.Add(ex.Message);
        }

    }
}