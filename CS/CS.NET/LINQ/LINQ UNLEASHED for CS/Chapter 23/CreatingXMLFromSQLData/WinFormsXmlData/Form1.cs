using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using System.IO;

namespace WinFormsXmlData
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {
      XDocument doc = XmlData.GetData();
      var elem = doc.XPathSelectElements("Customers/Customer");
      TextReader stream = new StringReader(doc.ToString());
      XmlReader reader = XmlReader.Create(stream);
      DataSet data = new DataSet();
      data.ReadXml(reader);

      dataGridView1.DataSource = reader;
      dataGridView1.Refresh();
    }
  }
}
