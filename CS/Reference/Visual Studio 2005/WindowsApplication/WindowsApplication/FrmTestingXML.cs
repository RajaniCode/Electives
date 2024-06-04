#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
#endregion

namespace WindowsApplicationCSharp
{
	partial class FrmTestingXML : Form
	{
		public FrmTestingXML()
		{
			InitializeComponent();
		}

		private void cmdLoadXml_Click(object sender, EventArgs e)
		{
			XmlTextReader objxmltextreader = new XmlTextReader("TestingXML.XML");
			string pstr;
			pstr = "Data in this XML";
			while (objxmltextreader.Read())
			{
				if (objxmltextreader.Value.Trim().Length != 0)
				{
					pstr = pstr + '\n' + objxmltextreader.Value;
				}
			}
			MessageBox.Show(pstr);
		}
	}
}