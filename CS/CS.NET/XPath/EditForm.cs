using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace XPath
{
	/// <summary>
	/// Summary description for EditForm.
	/// </summary>
	public class EditForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox artist;
		private System.Windows.Forms.TextBox price;
		private System.Windows.Forms.TextBox country;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.artist = new System.Windows.Forms.TextBox();
			this.price = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.country = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Artist:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Price:";
			// 
			// artist
			// 
			this.artist.Location = new System.Drawing.Point(96, 64);
			this.artist.Name = "artist";
			this.artist.Size = new System.Drawing.Size(128, 20);
			this.artist.TabIndex = 4;
			this.artist.Text = "";
			// 
			// price
			// 
			this.price.Location = new System.Drawing.Point(96, 100);
			this.price.Name = "price";
			this.price.Size = new System.Drawing.Size(128, 20);
			this.price.TabIndex = 5;
			this.price.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Country:";
			// 
			// country
			// 
			this.country.Location = new System.Drawing.Point(96, 136);
			this.country.Name = "country";
			this.country.Size = new System.Drawing.Size(128, 20);
			this.country.TabIndex = 7;
			this.country.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(40, 184);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 24);
			this.button1.TabIndex = 8;
			this.button1.Text = "Update";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(128, 184);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 24);
			this.button2.TabIndex = 9;
			this.button2.Text = "Insert";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(216, 184);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(72, 24);
			this.button3.TabIndex = 10;
			this.button3.Text = "Remove";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(96, 32);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(128, 21);
			this.comboBox1.TabIndex = 11;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// EditForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 221);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.country);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.price);
			this.Controls.Add(this.artist);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "EditForm";
			this.Text = "EditXml";
			this.Load += new System.EventHandler(this.EditForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		const string FILE_NAME = "data.xml";
		XPathDocument doc;
		XPathNavigator nav;
		XPathExpression expr; 
		XPathNodeIterator iterator;

		private void EditForm_Load(object sender, System.EventArgs e)
		{
			doc = new XPathDocument(FILE_NAME);
			nav = doc.CreateNavigator();
			
			// Compile a standard XPath expression
			
			expr = nav.Compile("/catalog/cd/title");
			iterator = nav.Select(expr);
			
			// Iterate on the node set
			comboBox1.Items.Clear();
			try
			{
				while (iterator.MoveNext())
				{
					XPathNavigator nav2 = iterator.Current.Clone();
					comboBox1.Items.Add(nav2.Value);	
					
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
			} 
			comboBox1.SelectedIndex = 0;

			//save old title 
			oldTitle = comboBox1.Text;
		}

		string oldTitle="";

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string str = comboBox1.Text;
			if(str=="") return;

			oldTitle = str;
			expr = nav.Compile("/catalog/cd[title='" + str + "']");
			iterator = nav.Select(expr);

			if(iterator.MoveNext())
			{
				XPathNavigator nav2 = iterator.Current.Clone();
				country.Text = nav2.GetAttribute("country","");
				nav2.MoveToFirstChild();
				
				nav2.MoveToNext();
				artist.Text = nav2.Value;
				nav2.MoveToNext();
				price.Text = nav2.Value;
			}
		}

		// insert new cd element
		private void button2_Click(object sender, System.EventArgs e)
		{

			try 
			{ 
				XmlTextReader reader = new XmlTextReader(FILE_NAME);
				XmlDocument doc = new XmlDocument(); 
				doc.Load(reader);
				reader.Close();
				XmlNode currNode; 

				XmlDocumentFragment docFrag = doc.CreateDocumentFragment(); 
				docFrag.InnerXml="<cd country=\"" + country.Text + "\">" + 
					"<title>" + this.comboBox1.Text + "</title>" + 
					"<artist>" + artist.Text + "</artist>" +
					"<price>" + price.Text + "</price>" +
					"</cd>"; 
				// insert the availability node into the document 
				currNode = doc.DocumentElement;
				currNode.InsertAfter(docFrag, currNode.LastChild); 
				//save the output to a file 
				doc.Save(FILE_NAME); 
				this.DialogResult = DialogResult.OK;
			} 
			catch (Exception ex) 
			{ 
				Console.WriteLine ("Exception: {0}", ex.ToString());
				this.DialogResult = DialogResult.Cancel;
			} 
		}

		//update cd node
		private void button1_Click(object sender, System.EventArgs e)
		{
			// basically the same as remove node
			try 
			{ 
				XmlTextReader reader = new XmlTextReader(FILE_NAME);
				XmlDocument doc = new XmlDocument(); 
				doc.Load(reader);
				reader.Close();
				
				//Select the cd node with the matching title
				XmlNode oldCd;
				XmlElement root = doc.DocumentElement;
				oldCd = root.SelectSingleNode("/catalog/cd[title='" + oldTitle + "']");

				XmlElement newCd = doc.CreateElement("cd");
				newCd.SetAttribute("country",country.Text);
				
				newCd.InnerXml = "<title>" + this.comboBox1.Text + "</title>" + 
					"<artist>" + artist.Text + "</artist>" +
					"<price>" + price.Text + "</price>";
					
				root.ReplaceChild(newCd, oldCd);
				//save the output to a file 
				doc.Save(FILE_NAME); 
				this.DialogResult = DialogResult.OK;
			} 
			catch (Exception ex) 
			{ 
				Console.WriteLine ("Exception: {0}", ex.ToString());
				this.DialogResult = DialogResult.Cancel;
			} 
		}

		// remove cd node
		private void button3_Click(object sender, System.EventArgs e)
		{
			try 
			{ 
				XmlTextReader reader = new XmlTextReader(FILE_NAME);
				XmlDocument doc = new XmlDocument(); 
				doc.Load(reader);
				reader.Close();
				
				//Select the cd node with the matching title
				XmlNode cd;
				XmlElement root = doc.DocumentElement;
				cd = root.SelectSingleNode("/catalog/cd[title='" + this.comboBox1.Text + "']");

				root.RemoveChild(cd);
				//save the output to a file 
				doc.Save(FILE_NAME); 
				this.DialogResult = DialogResult.OK;
			} 
			catch (Exception ex) 
			{ 
				Console.WriteLine ("Exception: {0}", ex.ToString());
				this.DialogResult = DialogResult.Cancel;
			} 
		}
	
	}
}
