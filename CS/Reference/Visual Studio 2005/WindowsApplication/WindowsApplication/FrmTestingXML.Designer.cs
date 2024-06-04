namespace WindowsApplicationCSharp
{
	partial class FrmTestingXML
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cmdLoadXml = new System.Windows.Forms.Button();
			this.SuspendLayout();
// 
// cmdLoadXml
// 
			this.cmdLoadXml.Location = new System.Drawing.Point(39, 76);
			this.cmdLoadXml.Name = "cmdLoadXml";
			this.cmdLoadXml.Size = new System.Drawing.Size(138, 24);
			this.cmdLoadXml.TabIndex = 0;
			this.cmdLoadXml.Text = "Load XML";
			this.cmdLoadXml.Click += new System.EventHandler(this.cmdLoadXml_Click);
// 
// FrmTestingXML
// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.cmdLoadXml);
			this.Name = "FrmTestingXML";
			this.Text = "Testing Sample XML";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdLoadXml;
	}
}

