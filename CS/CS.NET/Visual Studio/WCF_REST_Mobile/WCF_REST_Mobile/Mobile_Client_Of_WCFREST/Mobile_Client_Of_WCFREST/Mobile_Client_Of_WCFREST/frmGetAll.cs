using System;
 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Runtime.Serialization;

using System.Xml;
using System.Xml.Linq;
using System.Linq; 

namespace Mobile_Client_Of_WCFREST
{
    public partial class frmGetAll : Form
    {
        public frmGetAll()
        {
            InitializeComponent();
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {

            XmlReader xmlReader = XmlReader.Create("http://mahesh-pc/RESTVDDML/Service.svc/GetAllEmployee");

            XDocument xDoc = XDocument.Load(xmlReader) ;

            var EmpData = from emp in xDoc.Descendants("Employee")
                          select new Employee()
                          {
                              EmpNo = Convert.ToInt32(emp.Descendants("EmpNo").First().Value),
                              EmpName = emp.Descendants("EmpName").First().Value,
                              Salary = Convert.ToInt32(emp.Descendants("Salary").First().Value),
                              DeptNo = Convert.ToInt32(emp.Descendants("DeptNo").First().Value)
                          };
            dgEmployee.DataSource = EmpData.ToList(); 
  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}