#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace WindowsVersioningCSharp
{
	partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ClassLibraryVersion.Class1 objclass1 = new ClassLibraryVersion.Class1();
				MessageBox.Show(objclass1.Version());
		}
	}
}