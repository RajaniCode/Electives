using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Reflection;
using NUnit.Framework;
using OpenVue.XmlDbTier;

namespace OpenVue
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	[TestFixture] 
	public class UnitTest_ADO_NET_XML
	{
		[Test] public void XPathExtension() 
		{
			//Create an ODBC connection to the database. Here it is an Access file
			OdbcConnection conn = new OdbcConnection("DSN=XmlDb_NorthWind");

			//Create a DataSet with a name "XmlDb"
			DataSet dataset = new DataSet("XmlDb");

			//Create a DataAdapter to load data from original data source to the DataSet
			OdbcDataAdapter adapter = new OdbcDataAdapter();
			adapter.SelectCommand = new OdbcCommand("SELECT * FROM Orders", conn);
			adapter.Fill(dataset, "Orders");

			//Create a virtual XML document on top of the DataSet
			XmlDataDocument doc = new XmlDataDocument(dataset); 

			//Create an XPath navigator
			XPathNavigator nav = doc.CreateNavigator();

			//XPath expression
			String xpath = "//Orders[ex:year(ShippedDate)=1995 and ex:month(ShippedDate)<=3]";
			
			//Compile the XPath expression
			XPathExpression xpathexp = nav.Compile(xpath);

			//Assign a customized XPath context
			XmlDbXPathContext context = new XmlDbXPathContext(new NameTable());
			context.AddNamespace("ex", "http://openvue.net");
			xpathexp.SetContext(context);

			//Perform XPath query
			XPathNodeIterator it = nav.Select(xpathexp);

			//Output the result
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<Results>");

			while (it.MoveNext())
			{
				XmlElement elem = (XmlElement)((IHasXmlNode)it.Current).GetNode();
				stringBuilder.Append(elem.ChildNodes[4].OuterXml);
				DateTime dt = Convert.ToDateTime(elem.ChildNodes[4].InnerText);
				Assert.AreEqual(1995, dt.Year);
				Assert.IsTrue(dt.Month <= 3);
			}
			stringBuilder.Append("</Results>");
			XmlDocument docResult = new XmlDocument();
			docResult.LoadXml(stringBuilder.ToString());
			docResult.Save(Console.Out);
		}
		[Test] public void SingleTable2XML() 
		{
			//Create an ODBC connection to the database. Here it is an Access file
			OdbcConnection conn = new OdbcConnection("DSN=XmlDb_NorthWind");

			//Create a DataSet with a name "XmlDb"
			DataSet dataset = new DataSet("XmlDb");

			//Create a DataAdapter to load data from original data source to the DataSet
			OdbcDataAdapter adapter = new OdbcDataAdapter();
			adapter.SelectCommand = new OdbcCommand("SELECT * FROM Customers", conn);
			adapter.Fill(dataset, "Customers");

			//Create a virtual XML document on top of the DataSet
			XmlDataDocument doc = new XmlDataDocument(dataset); 

			//Output this XML document
			doc.Save(Console.Out);

			//NUnit tests to confirm the result is exactly what we expect
			Assert.AreEqual("XmlDb", doc.DocumentElement.LocalName);
			Assert.AreEqual("Customers", doc.DocumentElement.FirstChild.LocalName);
		}
		[Test] public void MasterDetailTables2XML() 
		{
			//Create an ODBC connection to the database. Here it is an Access file
			OdbcConnection conn = new OdbcConnection("DSN=XmlDb_NorthWind");

			//Create a DataSet with a name "XmlDb"
			DataSet dataset = new DataSet("XmlDb");

			//Load master table from original data source to the DataSet
			OdbcDataAdapter adapter = new OdbcDataAdapter();
			adapter.SelectCommand = new OdbcCommand("SELECT * FROM Customers", conn);
			adapter.Fill(dataset, "Customers");

			//Load detail table from original data source to the DataSet
			adapter.SelectCommand = new OdbcCommand("SELECT * FROM Orders", conn);
			adapter.Fill(dataset, "Orders");

			//Get the primary key column from the master table
			DataColumn primarykey = dataset.Tables["Customers"].Columns["CustomerID"];

			//Get the foreign key column from the detail table
			DataColumn foreignkey = dataset.Tables["Orders"].Columns["CustomerID"];

			//Assign a relation
			DataRelation relation = dataset.Relations.Add(primarykey, foreignkey);

			//Ask ADO.NET to generate nested XML nodes
			relation.Nested = true;

			//Create a virtual XML document on top of the DataSet
			XmlDataDocument doc = new XmlDataDocument(dataset); 

			//Output this XML document
			doc.Save(Console.Out);

			//NUnit tests to confirm the result is exactly what we expect
			Assert.AreEqual("XmlDb", doc.DocumentElement.LocalName);
			Assert.AreEqual("Customers", doc.DocumentElement.FirstChild.LocalName);
			Assert.AreEqual("Customers", doc.GetElementsByTagName("Orders")[0].ParentNode.LocalName);
		}
		[Test] public void QueryWithXPath() 
		{
			//Create an ODBC connection to the database. Here it is an Access file
			OdbcConnection conn = new OdbcConnection("DSN=XmlDb_NorthWind");

			//Create a DataSet with a name "XmlDb"
			DataSet dataset = new DataSet("XmlDb");

			//Load master table from original data source to the DataSet
			OdbcDataAdapter adapter = new OdbcDataAdapter();
			adapter.SelectCommand = new OdbcCommand("SELECT * FROM Customers", conn);
			adapter.Fill(dataset, "Customers");

			//Load detail table from original data source to the DataSet
			adapter.SelectCommand = new OdbcCommand("SELECT * FROM Orders", conn);
			adapter.Fill(dataset, "Orders");

			//Get the primary key column from the master table
			DataColumn primarykey = dataset.Tables["Customers"].Columns["CustomerID"];

			//Get the foreign key column from the detail table
			DataColumn foreignkey = dataset.Tables["Orders"].Columns["CustomerID"];

			//Assign a relation
			DataRelation relation = dataset.Relations.Add(primarykey, foreignkey);

			//Ask ADO.NET to generate nested XML nodes
			relation.Nested = true;

			//Create a virtual XML document on top of the DataSet
			XmlDataDocument doc = new XmlDataDocument(dataset); 

			//Create an output buffer
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<Results>");

			//Perform an XPath query
			XmlNodeList nodeList = doc.SelectNodes("/XmlDb/Customers/Orders[../City='Berlin' and ShipCountry='Germany']");
			
			//Visit results in the list
			foreach (XmlNode node in nodeList)
			{
				stringBuilder.Append(node.OuterXml);

				//NUnit tests to confirm the result is exactly what we expect
				Assert.AreEqual("ShipCountry", node.ChildNodes[10].LocalName);
				Assert.AreEqual("Germany", node.ChildNodes[10].InnerText);
				Assert.AreEqual("City", node.ParentNode.ChildNodes[5].LocalName);
				Assert.AreEqual("Berlin", node.ParentNode.ChildNodes[5].InnerText);
			}
			stringBuilder.Append("</Results>");
			XmlDocument docResult = new XmlDocument();
			docResult.LoadXml(stringBuilder.ToString());
			docResult.Save(Console.Out);
		}	
		[Test] public void MappingBetweenXmlElementAndDataRow() 
		{
			//Create an ODBC connection to the database. Here it is an Access file
			OdbcConnection conn = new OdbcConnection("DSN=XmlDb_NorthWind");

			//Create a DataSet with a name "XmlDb"
			DataSet dataset = new DataSet("XmlDb");

			//Create a DataAdapter to load data from original data source to the DataSet
			OdbcDataAdapter adapter = new OdbcDataAdapter();
			adapter.SelectCommand = new OdbcCommand("SELECT * FROM Products", conn);
			adapter.Fill(dataset, "Products");

			//Create a virtual XML document on top of the DataSet
			XmlDataDocument doc = new XmlDataDocument(dataset); 

			Console.WriteLine("=========== GetRowFromElement ================");

			//Perform XPath query
			XmlNodeList nodeList = doc.SelectNodes("/XmlDb/Products[CategoryID=3]");
			foreach (XmlNode node in nodeList)
			{
				//Map XmlElement to DataRow
				DataRow row = doc.GetRowFromElement((XmlElement) node);
				Console.WriteLine("Product Name = " + row["ProductName"]);
				Assert.AreEqual(3, row["CategoryID"]);
			}

			Console.WriteLine("=========== GetElementFromRow ================");

			//Perform ADO.NET native query
			DataRow[] rows = dataset.Tables["Products"].Select("CategoryID=3");
			foreach (DataRow row in rows)
			{
				//Map DataRow to XmlElement
				XmlElement elem = doc.GetElementFromRow(row);
				Console.WriteLine("Product Name = " + elem.ChildNodes[1].InnerText);
				Assert.AreEqual("3", elem.ChildNodes[2].InnerText);
			}
		}
		[Test] public void GenerateHTMLFromXSLT() 
		{
			//Create an ODBC connection to the database. Here it is an Access file
			OdbcConnection conn = new OdbcConnection("DSN=XmlDb_NorthWind");

			//Create a DataSet with a name "XmlDb"
			DataSet dataset = new DataSet("XmlDb");

			//Load "Products" table from original data source to the DataSet
			OdbcDataAdapter adapter = new OdbcDataAdapter();
			adapter.SelectCommand = new OdbcCommand("SELECT * FROM Products", conn);
			adapter.Fill(dataset, "Products");

			//Load "Order Details" table from original data source to the DataSet
			adapter.SelectCommand = new OdbcCommand("SELECT * FROM [Order Details]", conn);
			adapter.Fill(dataset, "OrderDetails");

			//Create a relationship between the two tables
			dataset.Relations.Add(
				dataset.Tables["Products"].Columns["ProductID"],
				dataset.Tables["OrderDetails"].Columns["ProductID"]).Nested = true;;

			//Build a virtual XML document on top of the DataSet
			XmlDataDocument doc = new XmlDataDocument(dataset); 

			//Load the XSLT file. NOTE: Here it is compiled as an embedded resource file
			Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			XslTransform xslTran = new XslTransform();
			Stream xslStream = assembly.GetManifestResourceStream("UnitTest_ADO.NET_XML.Test.xslt");
			XmlTextReader reader = new XmlTextReader(xslStream);
			xslTran.Load(reader, null, null);
            
			//Output the result a HTML file
			XmlTextWriter writer = new XmlTextWriter("xsltresult.html", System.Text.Encoding.UTF8);
			xslTran.Transform(doc.CreateNavigator(), null, writer, null);
			writer.Close();
		}
	}
}
